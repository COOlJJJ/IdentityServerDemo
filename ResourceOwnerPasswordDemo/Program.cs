using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ResourceOwnerPasswordDemo
{
    public class Program
    {

        /// <summary>
        /// 资源密码凭证模式
        /// 这种模式适用于鉴权服务器与资源服务器是高度相互信任的，例如两个服务都是同个团队或者同一公司开发的。
        /// 这种模式下，应用client可能存了用户密码这不安全性问题，所以才需要高可信的应用。
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
