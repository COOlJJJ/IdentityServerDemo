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
        /// ��ƪ��Ҫ�Կͻ���ƾ֤ģʽ������Ȩ
        /// ����ͨ������һ����֤��Ȩ���ʷ��񣬶���һ��API��ͨ��PostMan���ԣ�
        /// �ͻ���ͨ��IdentityServer������������ƣ���ʹ���������Ʒ���API
        /// ���ַ�ʽ���������ƣ�����Ե�����Ӧ�õģ�����������û��ģ����п��ܶ���û�����ͬһ�����ơ�
        /// ����ģʽһ��ֻ���ڷ����������֮�����֤
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
