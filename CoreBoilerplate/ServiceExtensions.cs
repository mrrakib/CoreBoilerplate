using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.LogicClasses;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API
{
    public static class ServiceExtensions
    {
        #region Config Swagger for API call
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Society Management API",
                    Description = "Society management Web API for society member manage.",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Rakibul Islam Biplob",
                        Email = string.Empty,
                        Url = new Uri("https://facebook.com/mrbiplob22"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }
        #endregion

        #region Enable CORS for cross domain call
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        #endregion

        #region Enable SQL Server for DB Connection
        public static void ConfigureSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepoContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
        #endregion

        #region Register all repo and services
        public static void ConfigureRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext, RepoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISocietyInfoRepository, SocietyInfoRepository>();
            services.AddScoped<ISocietyInfoService, SocietyInfoService>();
            services.AddScoped<ISocietyMemberRepository, SocietyMemberRepository>();
            services.AddScoped<ISocietyMemberService, SocietyMemberService>();
        }
        #endregion
    }
}
