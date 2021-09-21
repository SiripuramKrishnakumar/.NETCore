using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TextileERPClient.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TextileERPClient.ViewComponents
{
    public class UOMViewComponent : ViewComponent
    {
        private readonly Keys keys;
        public UOMViewComponent(IOptions<Keys> options)
        {
            this.keys = options.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(keys.ServiceURL);
                var httpResponse = await client.GetAsync("api/master/uoms");
                if(httpResponse.IsSuccessStatusCode)
                {
                    items = JsonConvert.DeserializeObject<List<SelectListItem>>(await httpResponse.Content.ReadAsStringAsync());
                }
            }
            return View(items);
        }
    }
}
