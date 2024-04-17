using FiestaMarketBackend.API.Extensions;
using FiestaMarketBackend.API.Middleware;
using FiestaMarketBackend.Application.Abstractions.Authentication;
using FiestaMarketBackend.Application.Abstractions.Behaviors;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Abstractions.Services;
using FiestaMarketBackend.Application.Product;
using FiestaMarketBackend.Application.User;
using FiestaMarketBackend.Core.Repositories;
using FiestaMarketBackend.Infrastructure;
using FiestaMarketBackend.Infrastructure.Authentication;
using FiestaMarketBackend.Infrastructure.Repositories;
using FiestaMarketBackend.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

var configuration = builder.Configuration;
//builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FiestaDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(FiestaDbContext)));
    });

builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = configuration.GetConnectionString("Cache"));

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository> ();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();

builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
builder.Services.Configure<AuthOptions>(configuration.GetSection(nameof(AuthOptions)));
builder.Services.AddApiAuthentication(configuration);
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

var requestPath = "/StaticFiles";
var staticFilesPath = Path.Combine(builder.Environment.ContentRootPath, "StaticFiles");
builder.Services.AddScoped<IFileService>(_ => new FileService(staticFilesPath, requestPath));

builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly);

        cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        cfg.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
        cfg.AddOpenBehavior(typeof(QueryCachingPipelineBehavior<,>));
        cfg.AddOpenBehavior(typeof(InvalidateCachePipelineBehavior<,>));
    });

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
});

app.UseMiddleware<RequestLogContextMiddleware>();

app.UseSerilogRequestLogging();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(staticFilesPath),
    RequestPath = requestPath
});

app.UseAuthentication();
app.UseAuthorization();


app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
