using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace IdentityServerDemo
{
    public class ApplicationUser : IdentityUser
    {
        //可以在这里扩展，下文会说到
        public string name { get; set; }
        public string RealName { get; set; }
        public int sex { get; set; } = 0;
        public int age { get; set; }
        public DateTime birth { get; set; } = DateTime.Now;
        public string addr { get; set; }
        public bool tdIsDelete { get; set; }
    }


    // 定义用户管理上下文，继承 NetCore 自带的 Identity 认证机制，也可以不继承而自定义表结构。
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
