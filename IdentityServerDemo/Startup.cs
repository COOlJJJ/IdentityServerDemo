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
            //  这个ApiScopes需要新加上，否则访问提示invalid_scope 
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
            }).AddConfigurationStore(options => //添加配置数据（ConfigurationDbContext上下文用户配置数据）
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            }).AddOperationalStore(options =>   //添加操作数据（PersistedGrantDbContext上下文 临时数据（如授权和刷新令牌））
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                // 自动清理 token ，可选
                options.EnableTokenCleanup = true;
                // 自动清理 token ，可选
                options.TokenCleanupInterval = 3600;
            }).AddTestUsers(TestUsers.Users);
            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();



            // 数据库配置系统应用用户数据上下文
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            // 启用 Identity 服务 添加指定的用户和角色类型的默认标识系统配置
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //在调用 http://localhost:5002/connect/userinfo 去获取Claims时  需要授权校验 不加就403 ~~~
            services.AddAuthentication("Bearer")
                     .AddIdentityServerAuthentication(options =>
                     {
                         options.Authority = "http://localhost:5002";//授权服务器地址
                         options.RequireHttpsMetadata = false;//是否Https
                         options.ApiName = "code_scope1";//配置的资源服务器名
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

            //使用静态文件 ID4 Web UI
            app.UseStaticFiles();

            //启用IdentityServer
            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
