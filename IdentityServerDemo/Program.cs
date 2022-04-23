using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityServerDemo
{
    public class Program
    {
        /// <summary>
        /// 一、迁移项目（ 使用 Package Manager Console ）：
        ///1、add-migration InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb 
        ///2、add-migration InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
        ///3、add-migration AppDbMigration -c ApplicationDbContext -o Data
        ///4、update-database -c PersistedGrantDbContext
        ///5、update-database -c ConfigurationDbContext
        ///6、update-database -c ApplicationDbContext
        /// ID4和EFCore数据持久化 ASP.NET Identity主要是角色用户管理 不包含授权和认证 通过和ID4结合是很好的
        /// 单点登陆SSO 结合前端Vue Oidc
        /// ID4 UI 下载看老张博客
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var seed = args.Contains("/seed");
            if (seed)
            {
                args = args.Except(new[] { "/seed" }).ToArray();
            }
            var host = CreateHostBuilder(args).Build();
            if (seed)
            {
                SeedData.EnsureSeedData(host.Services);
            }
            host.Run();
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
