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
        /// ��Ȩ��ģʽ����˼�ģʽ����tokenЯ����url�У���ȫ�Է��治�ܱ�֤���⣬��ͨ����Ȩ���ģʽ��ֱ�ӷ���token��
        /// �����ȷ���һ����Ȩ�룬Ȼ���ٸ��������Ȩ��ȥ����token���������token���������Ҫ���ں�̨�����ַ�ʽҲ��Ϊ��ȫ���������к�˵�Ӧ��
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
