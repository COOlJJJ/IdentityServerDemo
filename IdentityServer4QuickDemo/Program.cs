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
        ///1.�ڱ�ƪ������ͨ���ֶ����߹ٷ�ģ��ķ�ʽ���׵�ʵ�������ǵ�IdentityServer��Ȩ�����������������Ӧ�����ú�UI���ã�ʵ���˻�ȡToken��ʽ��
        ///2.������Ӧ������������Ҫע�����������ǣ�����Щ�û�(users)����ͨ����Щ�ͻ���(clents)���������ǵ���ЩAPI������Դ(API)��
        /// ID4��ȡToken������Ŀ
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
