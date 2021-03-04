using System;
using BlazorBlog.Server.Contracts;
using BlazorBlog.Server.Data;
using BlazorBlog.Server.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace BlazorBlog.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    //builder => builder.WithOrigins("https://")
                        .WithMethods("POST", "GET")
                        .AllowAnyHeader());
                        //.WithHeaders("accept", "content-type"));
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<AMCDbContext>(options => options.UseMySql(connectionString,
                mysqlOptions =>
                    mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 3, 27), ServerType.MariaDb))));
        }

        public static void ConfigureDataWrapper(this IServiceCollection services)
        {
            services.AddScoped<IDataWrapper, DataWrapper>();
        }
    }
}