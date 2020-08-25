using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using TrackerAPI.Models;
using TrackerDB;


namespace TrackerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITrackerRepository, TrackerRepository>();
            //services.AddDbContext<TrackerDbContext>(opt => opt.UseSqlServer("DefaultConnection"));
            services.AddScoped<TrackerDbContext>(_ => new TrackerDbContext(Configuration.GetConnectionString("DefaultConnection"), Configuration.GetValue<bool>("UsePostGres", false )));

            services.BuildServiceProvider()
                    .GetService<TrackerDbContext>().Database
                    .Migrate();

            services.AddRazorPages();
            //services.AddMvc();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseEndpoints(endpoint => {
                endpoint.MapControllers();
            });
            
        }
    }
}
