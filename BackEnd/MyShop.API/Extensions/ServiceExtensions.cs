using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyShop.Application.Interfaces;
using MyShop.Application.Services;
using MyShop.Domain.IRepositories;
using MyShop.Infrastructure.Data;
using MyShop.infrastructure.Repositories;
using MyShop.Infrastructure.Repositories;

namespace MyShop.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection service, string connectionString)
    {
        service.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        return service;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IOrderRepository, OrderRepository>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<ITagRepository, TagRepository>();
        service.AddScoped<IUserRepository, UserRepository>();
        
        return service;
    }

    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddScoped<IOrderService, OrderService>();
        service.AddScoped<IProductService, ProductService>();

        return service;
    }

    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection service)
    {
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Event Management Platform Api",
                Version = "v1",
                Description = "API Documentation",
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            c.IncludeXmlComments(xmlPath);

        });
        
        return service;
    }

    public static IServiceCollection AddMyCors(this IServiceCollection service)
    {
        service.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        
        return service;
    }

}