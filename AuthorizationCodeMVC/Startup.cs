using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthorizationCodeMVC
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
            services.AddControllersWithViews();
            services.AddAuthorization();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                   .AddCookie("Cookies")  //使用Cookie作为验证用户的首选方式
                  .AddOpenIdConnect("oidc", options =>
                  {
                      options.Authority = "http://localhost:5000";  //授权服务器地址
                  options.RequireHttpsMetadata = false;  //暂时不用https
                  options.ClientId = "code_client";
                      options.ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A";
                      options.ResponseType = "code"; //代表Authorization Code
                  options.Scope.Add("code_scope1"); //添加授权资源
                  options.SaveTokens = true; //表示把获取的Token存到Cookie中
                  options.GetClaimsFromUserInfoEndpoint = true;
                  });
            services.ConfigureNonBreakingSameSiteCookies();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
