using FiestaMarketBackend.Application.Products.Commands;
using FiestaMarketBackend.Application.Services;
using FiestaMarketBackend.Infrastructure;
using FiestaMarketBackend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FiestaDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(FiestaDbContext)));
    });

builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<NewsRepository>();
builder.Services.AddScoped<CategoryRepository>();

var requestPath = "/StaticFiles";
var staticFilesPath = Path.Combine(builder.Environment.ContentRootPath, "StaticFiles");
builder.Services.AddScoped(f => new FileService(staticFilesPath, requestPath));

builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(staticFilesPath),
    RequestPath = requestPath
});

app.UseAuthorization();

app.MapControllers();

app.Run();
