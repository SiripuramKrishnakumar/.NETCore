using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextileERPClient.Models;

namespace TextileERPClient.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly Keys keys;
        public BaseController(ILogger<BaseController> logger, IConfiguration configuration, IOptions<Keys> options)
        {
            keys = options.Value;
            this.logger = logger;
            this.configuration = configuration;
        }

        private string _userauth;
        protected string UserAuth
        {
            get
            {
                _userauth = HttpContext.Session.GetString("AuthUser");
                return _userauth;
            }
        }
        [HttpPost]
        public IActionResult UserAuthentication(User user)
        {
            if (user != null && (user.UserName == "admin" && user.Password == "admin@KK"))
            {
                HttpContext.Session.SetString("AuthUser", "KK Siripuram");
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid Credentials.";
                return RedirectToAction("Login", "Home");
            }
        }
        public string UserSession()
        {
            string auth = HttpContext.Session.GetString("AuthUser");
            if (!string.IsNullOrEmpty(auth))
            {
                HttpContext.Session.SetString("AuthUser", auth);
                return auth;
            }
            else
            {
                return null;
            }

        }
    }
}
