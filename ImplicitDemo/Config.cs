using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplicitDemo
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
           new IdentityResource[]
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
           };


        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("Implicit_scope1")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {

                new ApiResource("api1","api1")
                {
                    Scopes={ "Implicit_scope1" },
                    ApiSecrets={new Secret("apipwd".Sha256())}  //api密钥
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                 new Client
                {
                    ClientId = "Implicit_client",
                    ClientName = "Implicit Auth",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris ={
                    "http://localhost:5002/signin-oidc",  //跳转登录到的客户端的地址
                    },
                    PostLogoutRedirectUris ={
                        "http://localhost:5002/signout-callback-oidc",//跳转登出到的客户端的地址
                    },
                    AllowedScopes = {
                           IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                         "Implicit_scope1"
                     },
                      // 是否需要同意授权 （默认是false）
                      RequireConsent=true
                 },
            };
    }
}
