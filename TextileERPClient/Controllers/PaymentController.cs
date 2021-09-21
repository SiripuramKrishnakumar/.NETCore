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
    public class PaymentController : BaseController
    {
        public PaymentController(ILogger<BaseController> logger, IConfiguration configuration, IOptions<Keys> options) : base(logger, configuration, options)
        {
        }

        public IActionResult Bills()
        {
            return View();
        }
    }
}
