using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //身份认证服务
            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", config =>
            {
                config.Cookie.Name = "CookieAuthDemo";
                config.LoginPath = "/home/authenticate";
            });
           services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //身份认证
            app.UseAuthentication();
            //授权
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
              
                    //await context.Response.WriteAsync("Hello World!");
                    endpoints.MapDefaultControllerRoute();
                
            });
        }
    }
}
