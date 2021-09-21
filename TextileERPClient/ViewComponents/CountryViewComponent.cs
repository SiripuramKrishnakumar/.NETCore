using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TextileERPClient.Models;

namespace TextileERPClient.ViewComponents
{
    public class CountryViewComponent : ViewComponent
    {
        private readonly Keys keys;
        public CountryViewComponent(IOptions<Keys> options)
        {
            this.keys = options.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =new Uri(keys.ServiceURL);
                string res = await client.GetStringAsync("api/master/ddcountries");
                if(res != null && res.Length > 0)
                {
                    listItems = JsonConvert.DeserializeObject<List<SelectListItem>>(res);
                }
                
                Console.WriteLine(res);
                return View(listItems);
            }
        }
    }
}
