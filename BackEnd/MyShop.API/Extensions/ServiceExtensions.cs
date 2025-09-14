using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public static IServiceCollection AddMyDbContext(this IServiceCollection service, string connectionString)
    {
        service.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString)
                    .EnableSensitiveDataLogging() // полезно для дебага
        );
        
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
        service.AddScoped<ITagService, TagService>();
        service.AddScoped<ICategoryService, CategoryService>();

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
    
    public static IServiceCollection AddMyAuthentication(this IServiceCollection service, IConfiguration jwtSettings)
    {
        service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!))
                };
            });
        return service;
    }

}