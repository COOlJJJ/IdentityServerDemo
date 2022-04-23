using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthorizationCodeMVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace AuthorizationCodeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            ViewData["Message"] = "Secure page.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 测试请求API资源(api1)
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> getApi()
        {
            var client = new HttpClient();
            //这个是获取授权服务器返回的accesstoken
            //访问令牌（AccessToken）直接通过浏览器传输，就增加了一定的安全问题。因为访问令牌比身份令牌更敏感
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            if (string.IsNullOrEmpty(accessToken))
            {
                return Json(new { msg = "accesstoken 获取失败" });
            }
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var httpResponse = await client.GetAsync("http://localhost:5001/api/identity/GetUserClaims");
            var result = await httpResponse.Content.ReadAsStringAsync();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return Json(new { msg = "请求 api1 失败。", error = result });
            }
            return Json(new
            {
                msg = "成功",
                data = JsonConvert.DeserializeObject(result)
            });
        }
    }
}
