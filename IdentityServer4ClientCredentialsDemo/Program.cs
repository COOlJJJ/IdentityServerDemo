using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityServer4ClientCredentialsDemo
{
    public class Program
    {
        /// <summary>
        /// 本篇主要以客户端凭证模式进行授权
        /// 我们通过创建一个认证授权访问服务，定义一个API和通过PostMan测试，
        /// 客户端通过IdentityServer上请求访问令牌，并使用它来控制访问API
        /// 这种方式给出的令牌，是针对第三方应用的，而不是针对用户的，即有可能多个用户共享同一个令牌。
        /// 这种模式一般只用在服务端与服务端之间的认证
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
