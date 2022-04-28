using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookieDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult PrivatePage()
        {
            ClaimsPrincipal currentuser = HttpContext.User;

            return View(currentuser.Claims);
        }

        public IActionResult Authenticate()
        {
            //描述一个用户
            var UserClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Jact"),
                new Claim(ClaimTypes.GivenName,"Jee"),
                new Claim(ClaimTypes.Email,"Jact@163.com")
            };
            var UserIdentity = new ClaimsIdentity(UserClaims, "UserIdentity");
            var UserPrincipal = new ClaimsPrincipal(new[] { UserIdentity});
            HttpContext.SignInAsync(UserPrincipal);

            return RedirectToAction("Index");
        }
    }
}
