using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AuthorizationCodeDemo
{
    public class Program
    {
        /// <summary>
        /// 授权码模式解决了简化模式由于token携带在url中，安全性方面不能保证问题，而通过授权码的模式不直接返回token，
        /// 而是先返回一个授权码，然后再根据这个授权码去请求token，这个请求token这个过程需要放在后台，这种方式也更为安全。适用于有后端的应用
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
