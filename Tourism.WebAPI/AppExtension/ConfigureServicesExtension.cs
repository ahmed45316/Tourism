using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tourism.Service.Profiler;

namespace Tourism.WebAPI.AppExtension
{

    /// <summary>
    /// 
    /// </summary>
    public static class ConfigureServicesExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.DatabaseConfig(configuration);
            services.RegisterCores();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperConfiguration)));
            return services;
        }
        private static void DatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("CodesContext");
            var rowNumberForPagging = bool.Parse(configuration["RowNumberForPagging"]);
            if (rowNumberForPagging)
            {
                //services.AddDbContext<CodesContext>(options => options.UseSqlServer(connection, builder => builder.UseRowNumberForPaging()));
            }
            else
            {
               // services.AddDbContext<CodesContext>(options => options.UseSqlServer(connection));
            }

            //services.AddScoped<DbContext, CodesContext>();
        }
        private static void RegisterCores(this IServiceCollection services)
        {
           // services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));
            //services.AddTransient(typeof(IServiceBaseParameter<>), typeof(ServiceBaseParameter<>));
           // services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            //var servicesToScan = Assembly.GetAssembly(typeof(CompanyServices)); //..or whatever assembly you need
           // services.RegisterAssemblyPublicNonGenericClasses(servicesToScan)
             // .Where(c => c.Name.EndsWith("Services"))
             // .AsPublicImplementedInterfaces();
        }
    }
}
