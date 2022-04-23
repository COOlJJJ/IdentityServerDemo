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
        /// ����Ȩģʽ
        /// ��ģʽ��implicit grant type����ͨ��������Ӧ�ó���ķ�������ֱ���������������֤�������������ƣ�
        /// ������"��Ȩ��"�������(��Ȩ��ģʽ������˵��)�����в��������������ɣ����ƶԷ������ǿɼ��ģ�
        /// �ҿͻ��˲���Ҫ��֤��
        /// ���ַ�ʽ������ֱ�Ӵ���ǰ�ˣ��Ǻܲ���ȫ�ġ���ˣ�ֻ������һЩ��ȫҪ�󲻸ߵĳ�����
        /// �������Ƶ���Ч�ڱ���ǳ��̣�ͨ�����ǻỰ�ڼ䣨session����Ч��������ص������ƾ�ʧЧ�ˡ�
        /// ����ģʽ���ڰ�ȫ�Կ��ǣ������tokenʱЧ���ö�һЩ, ��֧��refresh token
        /// 
        /// �� Authorization Server �������һƪ��Դ����ƾ֤ģʽ�кβ�֮ͬ���أ�
        /// ��Config�����ÿͻ���(client)�ж�����һ��AllowedGrantTypes�����ԣ�������Ծ�����Client���Ա�����ģʽ�����ʣ�GrantTypes.ImplicitΪ����Ȩ�������ڱ�����������Ҫ���һ��Client����֧�ּ���Ȩ(implicit)��
        ///  ����Ȩ��ͨ��������Ӧ�ó���ķ�������ֱ���������������֤�������������ƣ����в��������������ɣ�������Ҫ���ö�Ӧ�Ļص���ַ�͵ǳ���ַ����Ҳ�ǲ�ͬ��֮ǰ����Դ������ƾ֤ģʽ��
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
