#pragma checksum "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bacd42e26260e6782dc1f708270fe868ef65f774"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\_ViewImports.cshtml"
using AuthorizationCodeMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\_ViewImports.cshtml"
using AuthorizationCodeMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bacd42e26260e6782dc1f708270fe868ef65f774", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70af65636b62c68dd898c6595438cc5e02c8df9d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Claims</h2>\r\n\r\n<dl>\r\n");
#nullable restore
#line 6 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 8 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml"
       Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 9 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml"
       Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 10 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\r\n\r\n<h2>Properties</h2>\r\n\r\n<dl>\r\n");
#nullable restore
#line 16 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml"
     foreach (var prop in (await Context.AuthenticateAsync()).Properties.Items)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 18 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml"
       Write(prop.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 19 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml"
       Write(prop.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 20 "D:\MyDemo\Study\IdentityServerDemo\AuthorizationCodeMVC\Views\Home\Privacy.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
