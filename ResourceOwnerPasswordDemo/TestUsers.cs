using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResourceOwnerPasswordDemo
{
    public class TestUsers
    {
        /// <summary>
        /// 因为是资源所有者密码凭证授权的方式，所以我们通过代码的方式来创建几个测试用户。
        /// </summary>
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "1",
                        Username = "i3yuan",
                        Password = "123456",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "i3yuan Smith"),
                            new Claim(JwtClaimTypes.GivenName, "i3yuan"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "i3yuan@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://i3yuan.top"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),


                            new Claim(JwtClaimTypes.Role,"admin")  //添加角色
                        }
                    }
                };
            }
        }
    }
}
