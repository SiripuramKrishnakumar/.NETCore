using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TextileERPClient.Models;
using Newtonsoft.Json;
namespace TextileERPClient.Controllers
{
    public class MasterController : BaseController
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly Keys keys;
        public MasterController(ILogger<MasterController> logger, IConfiguration configuration, IOptions<Keys> options):base(logger,configuration,options)
        {
            keys = options.Value;
            this.logger = logger;
            this.configuration = configuration;
        }
        public IActionResult Fabrics()
        {
            return View();
        }
        public IActionResult Customers()
        {
            return View();
        }
       
        [HttpPost]
        [Route("master/customerlist")]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(keys.ServiceURL);
                HttpResponseMessage httpResponse = await client.GetAsync("api/master/customerlist");
                var custlist = JsonConvert.DeserializeObject<List<Customer>>(await httpResponse.Content.ReadAsStringAsync());
                return custlist;
            }
        }
    }
}
