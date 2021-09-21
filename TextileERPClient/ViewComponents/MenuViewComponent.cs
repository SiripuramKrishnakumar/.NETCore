using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TextileERPClient.Models;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace TextileERPClient.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly Keys keys;
        public MenuViewComponent(IOptions<Keys> options)
        {
            keys = options.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var items = await GetMenuItems();
                return View(items);
            
        }

        private async Task<List<MenuItems>> GetMenuItems()
        {
            string auth = HttpContext.Session.GetString("AuthUser");
            List<MenuItems> items = new List<MenuItems>();
            HttpResponseMessage res;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(keys.ServiceURL);
               
                if(string.IsNullOrEmpty(auth))
                {
                     res = await client.GetAsync("api/master/menuitems/user");
                }
                else
                {
                     res = await client.GetAsync("api/master/menuitems/admin");
                }

                if (res.IsSuccessStatusCode)
                {
                    items = JsonConvert.DeserializeObject<List<MenuItems>>(await res.Content.ReadAsStringAsync());
                    return items;
                }
                else
                {
                    return null;
                }
            }
               
        }

    }
}
