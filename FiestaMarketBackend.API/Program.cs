using FiestaMarketBackend.API.Middleware;
using FiestaMarketBackend.Application.Abstractions.Behaviors;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Product.Commands;
using FiestaMarketBackend.Application.Services;
using FiestaMarketBackend.Application.User.Commands;
using FiestaMarketBackend.Infrastructure;
using FiestaMarketBackend.Infrastructure.Repositories;
using FluentValidation;
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

builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<NewsRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ICacheService, CacheService>();
//builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

var requestPath = "/StaticFiles";
var staticFilesPath = Path.Combine(builder.Environment.ContentRootPath, "StaticFiles");
builder.Services.AddScoped<FileService>(_ => new FileService(staticFilesPath, requestPath));

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

app.UseMiddleware<RequestLogContextMiddleware>();

app.UseSerilogRequestLogging();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(staticFilesPath),
    RequestPath = requestPath
});

app.UseAuthorization();

//app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
