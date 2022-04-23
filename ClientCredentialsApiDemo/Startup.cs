using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientCredentialsApiDemo
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
            services.AddControllersWithViews();
            services.AddAuthorization();
            ///AddAuthentication把Bearer配置成默认模式，将身份认证服务添加到DI中。
            ///AddIdentityServerAuthentication把IdentityServer的access token添加到DI中，供身份认证服务使用。
            services.AddAuthentication("Bearer")
              .AddIdentityServerAuthentication(options =>
              {
                  //认证Url
                  options.Authority = "http://localhost:5001";
                  //不使用Https
                  options.RequireHttpsMetadata = false;
                  options.ApiName = "api1";
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //UseAuthentication将身份验证中间件添加到管道中；
            //UseAuthorization 将启动授权中间件添加到管道中，以便在每次调用主机时执行身份验证授权功能。
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
