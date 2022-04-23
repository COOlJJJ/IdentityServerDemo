using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityServer4QuickDemo
{
    public class Program
    {
        /// <summary>
        ///1.在本篇中我们通过手动或者官方模板的方式简易的实现了我们的IdentityServer授权服务器搭建，并做了相应的配置和UI配置，实现了获取Token方式。
        ///2.对于相应的配置我们需要注意的三个点就是，有哪些用户(users)可以通过哪些客户端(clents)来访问我们的哪些API保护资源(API)。
        /// ID4获取Token简易项目
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
