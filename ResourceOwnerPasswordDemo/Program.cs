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
        /// ��Դ����ƾ֤ģʽ
        /// ����ģʽ�����ڼ�Ȩ����������Դ�������Ǹ߶��໥���εģ���������������ͬ���Ŷӻ���ͬһ��˾�����ġ�
        /// ����ģʽ�£�Ӧ��client���ܴ����û������ⲻ��ȫ�����⣬���Բ���Ҫ�߿��ŵ�Ӧ�á�
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
