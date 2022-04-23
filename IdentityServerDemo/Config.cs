using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServerDemo
{
    public static class Config
    {
        //有哪些用户可以通过哪些客户端来访问我们的哪些API保护资源。
        public static IEnumerable<IdentityResource> IdentityResources =>
       new IdentityResource[]
   {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
        {
        new ApiScope("code_scope1")
        };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
        {
        new ApiResource("api1","api1")
        {
            Scopes={ "code_scope1" },
            UserClaims={JwtClaimTypes.Role},  //添加Cliam 角色类型
            ApiSecrets={new Secret("apipwd".Sha256())}
        }
        };

        // 哪些客户端 Client（应用） 可以使用这个 Authorization Server
        public static IEnumerable<Client> Clients =>
            new Client[]
        {
        new Client
        {
            ClientId = "vue client",
            ClientName = "code Auth",
            //授权码模式
            AllowedGrantTypes = GrantTypes.Code,

            RedirectUris ={
                "http://localhost:8080/callback", //跳转登录到的客户端的地址
            },
            //跳转登出到的客户端的地址
            PostLogoutRedirectUris ={
                "http://localhost:8080/signout-callback-oidc",
            },
            ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

            AllowedScopes = {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "code_scope1"
            },
            //允许将token通过浏览器传递
            AllowAccessTokensViaBrowser=true,
            // 是否需要同意授权 （默认是false）
            RequireConsent=true
        }
        };



    }

}
