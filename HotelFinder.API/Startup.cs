using HotelFinder.Businness.Abstract;
using HotelFinder.Businness.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelFinder.API
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
            services.AddControllers();
            services.AddSingleton<IHotelService, HotelService>();
            services.AddSingleton<IHotelRepository, HotelRepository>();
            services.AddSwaggerDocument(
                config =>
                {
                    config.PostProcess = (doc =>
                    {
                        doc.Info.Title = "Hotels API";
                        doc.Info.Version = "1.0.0";
                        doc.Info.Contact = new NSwag.OpenApiContact() {
                            Name = "Baran Açıkgöz",
                            Url = "https://github.com/baranacikgoz",
                            Email = "baran-acikgoz@putlook.com"
                        };
                        {
                         
                    }
                    });
                    
                });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
