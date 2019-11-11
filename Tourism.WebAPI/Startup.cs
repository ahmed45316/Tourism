using Common.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tourism.WebAPI.AppExtension;

namespace Tourism.WebAPI
{
    /// <summary>
    /// startup class 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="configuration">Cary all configuration for json files</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Contract for collections (ioc) </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterCommonServices(Configuration);
            services.RegisterServices(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Provide middleware</param>
        /// <param name="env">Provide info about hosting</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Configure(env, Configuration);
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseHsts();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
