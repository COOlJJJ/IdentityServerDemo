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
            ///AddAuthentication��Bearer���ó�Ĭ��ģʽ���������֤������ӵ�DI�С�
            ///AddIdentityServerAuthentication��IdentityServer��access token��ӵ�DI�У��������֤����ʹ�á�
            services.AddAuthentication("Bearer")
              .AddIdentityServerAuthentication(options =>
              {
                  //��֤Url
                  options.Authority = "http://localhost:5001";
                  //��ʹ��Https
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
            //UseAuthentication�������֤�м����ӵ��ܵ��У�
            //UseAuthorization ��������Ȩ�м����ӵ��ܵ��У��Ա���ÿ�ε�������ʱִ�������֤��Ȩ���ܡ�
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
