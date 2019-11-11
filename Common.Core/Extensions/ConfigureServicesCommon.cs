using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common.Core.Core;
using Common.Core.RestSharp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Common.Core.Extensions
{
    public static class ConfigureServicesCommon
    {
        public static IServiceCollection RegisterCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            services.RegisterMainCore(configuration);
            services.AddApiDocumentationServices(configuration);
            services.JwtSettings(configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
        private static void JwtSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                };
            });
        }
        private static void RegisterMainCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IResponseResult, ResponseResult>();
            services.AddTransient<IResult, Result>();
            services.AddTransient<IDataPagging, DataPagging>();
            services.AddTransient<IImageConfig, ImageConfig>();
            services.AddSingleton<IRestSharpContainer>(x => new RestSharpContainer(configuration["APIGetWayUrl"], x.GetRequiredService<IHttpContextAccessor>()));
        }
        private static void AddApiDocumentationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                var title = configuration["SwaggerConfig:Title"];
                var version = configuration["SwaggerConfig:Version"];
                var docPath = configuration["SwaggerConfig:DocPath"];
                options.SwaggerDoc(version, new Info { Title = title, Version = version });
                options.DescribeAllEnumsAsStrings();
                var filePath = Path.Combine(AppContext.BaseDirectory, docPath);
                options.IncludeXmlComments(filePath);
                var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string>() } };
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                options.AddSecurityRequirement(security);

            });
        }
    }
}
