using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ReverseProxy {
    public class Startup {

        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();
            services.AddReverseProxy ()
                .LoadFromConfig (Configuration.GetSection ("Yarp"))
                .AddTransforms<DaprTransformProvider>(); //加上自定义转换
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger) {
            //  app.UseHttpsRedirection ();

            app.UseRouting ();
            app.UseAuthorization ();
            app.UseEndpoints (endpoints => {

                endpoints.MapControllers ();
                endpoints.MapReverseProxy (proxyPipeline => {

                    proxyPipeline.UseLoadBalancing ();
                });
               logger.LogWarning (Configuration.GetServiceUri ("api2")?.ToString());
                              logger.LogWarning (Configuration.GetServiceUri ("api1")?.ToString());


            });

        }
    }
}