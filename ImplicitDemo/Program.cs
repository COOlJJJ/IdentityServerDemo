using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ImplicitDemo
{
    public class Program
    {
        /// <summary>
        /// 简化授权模式
        /// 简化模式（implicit grant type）不通过第三方应用程序的服务器，直接在浏览器中向认证服务器申请令牌，
        /// 跳过了"授权码"这个步骤(授权码模式后续会说明)。所有步骤在浏览器中完成，令牌对访问者是可见的，
        /// 且客户端不需要认证。
        /// 这种方式把令牌直接传给前端，是很不安全的。因此，只能用于一些安全要求不高的场景，
        /// 并且令牌的有效期必须非常短，通常就是会话期间（session）有效，浏览器关掉，令牌就失效了。
        /// 这种模式基于安全性考虑，建议把token时效设置短一些, 不支持refresh token
        /// 
        /// 这搭建 Authorization Server 服务跟上一篇资源密码凭证模式有何不同之处呢？
        /// 在Config中配置客户端(client)中定义了一个AllowedGrantTypes的属性，这个属性决定了Client可以被哪种模式被访问，GrantTypes.Implicit为简化授权。所以在本文中我们需要添加一个Client用于支持简化授权(implicit)。
        ///  简化授权不通过第三方应用程序的服务器，直接在浏览器中向认证服务器申请令牌，所有步骤在浏览器中完成，所以需要配置对应的回调地址和登出地址。这也是不同于之前的资源所有者凭证模式。
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
