using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace IdentityServerDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "User id=sa;Password=~;Database=ID4;Server=MD2SA1PC\\SQLEXPRESS;Connect Timeout=50;Max Pool size=200;Min pool Size=5";

            services.AddControllersWithViews();
            services.AddCors(options => { options.AddPolicy("CorsPolicy", builder => builder.SetIsOriginAllowed((host) => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()); });

            // in memory config
            //services.AddIdentityServer()
            //  .AddDeveloperSigningCredential()
            //  .AddInMemoryApiResources(InMemoryConfig.GetApiResources())
            //  .AddTestUsers(InMemoryConfig.Users().ToList())
            //  ���ApiScopes��Ҫ�¼��ϣ����������ʾinvalid_scope 
            //  .AddInMemoryApiScopes(InMemoryConfig.GetApiScopes())
            //  .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResourceResources())
            //  .AddInMemoryClients(InMemoryConfig.GetClients());
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            // in DB  config
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            }).AddConfigurationStore(options => //����������ݣ�ConfigurationDbContext�������û��������ݣ�
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            }).AddOperationalStore(options =>   //��Ӳ������ݣ�PersistedGrantDbContext������ ��ʱ���ݣ�����Ȩ��ˢ�����ƣ���
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                // �Զ����� token ����ѡ
                options.EnableTokenCleanup = true;
                // �Զ����� token ����ѡ
                options.TokenCleanupInterval = 3600;
            }).AddTestUsers(TestUsers.Users);
            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();



            // ���ݿ�����ϵͳӦ���û�����������
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            // ���� Identity ���� ���ָ�����û��ͽ�ɫ���͵�Ĭ�ϱ�ʶϵͳ����
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //�ڵ��� http://localhost:5002/connect/userinfo ȥ��ȡClaimsʱ  ��Ҫ��ȨУ�� ���Ӿ�403 ~~~
            services.AddAuthentication("Bearer")
                     .AddIdentityServerAuthentication(options =>
                     {
                         options.Authority = "http://localhost:5002";//��Ȩ��������ַ
                         options.RequireHttpsMetadata = false;//�Ƿ�Https
                         options.ApiName = "code_scope1";//���õ���Դ��������
                     });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseRouting();

            //ʹ�þ�̬�ļ� ID4 Web UI
            app.UseStaticFiles();

            //����IdentityServer
            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
