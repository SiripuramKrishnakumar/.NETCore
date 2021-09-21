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
    public class TransactionController : BaseController
    {
        public TransactionController(ILogger<BaseController> logger, IConfiguration configuration, IOptions<Keys> options) : base(logger, configuration, options)
        {
        }

        public IActionResult Invoices()
        {
            return View();
        }
    }
}
