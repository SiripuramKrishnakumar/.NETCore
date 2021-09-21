using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextileERPService.AppData
{
    public class MenuItems
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Label { get; set; }
        public List<SubMenu> SubMenus { get; set; }
    }
    public class SubMenu
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Label { get; set; }
    }
}
