using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextileERPService.Context;
using TextileERPService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TextileERPService.AppData;

namespace TextileERPService.Controllers
{
    [Route("api/master")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly ERPContext context;
        private readonly IConfiguration configuration;
        private readonly ILogger<MasterController> logger;
        public MasterController(ERPContext context,IConfiguration configuration, IOptions<Keys> options,ILogger<MasterController> logger)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
            Keys keys = options.Value;
        }
        [HttpGet("ddcountries")]
        public IEnumerable<DropDownItem> GetCountries()
        {
            var countries = context.Countries.Select(i=> new DropDownItem { Text = i.CountryName , Value = i.Id.ToString()}).AsEnumerable();
            return countries;
        }
        [HttpGet("menuitems/{role}")]
        public IEnumerable<MenuItems> GetMenuItems(string role)
        {
            List<MenuItems> items = new List<MenuItems>();

            if (!String.IsNullOrEmpty(role) && role == "admin")
            {
                items.AddRange(new List<MenuItems>()
                {
                    new MenuItems{ Controller = "Home",Action="Dashboard",Label="Dashboard"},
                    new MenuItems{ Controller = "Master",Action="",Label="Master",SubMenus = new List<SubMenu>(){ 
                        new SubMenu { Controller = "Master", Action = "Fabrics", Label = "Fabrics" } ,
                        new SubMenu { Controller = "Master", Action = "Customers", Label = "Customers" } 
                    } },
                    new MenuItems{ Controller = "Transaction",Action="Invoices",Label="Invoices"},
                    new MenuItems{ Controller = "Payment",Action="Bills",Label="Payments"},
                    new MenuItems{ Controller = "Home",Action="Logout",Label="Logout"}
                });
            }
            else
            {
                items.AddRange(new List<MenuItems>()
                {
                    new MenuItems{ Controller = "Home",Action="Index",Label="Home"},
                    new MenuItems{ Controller = "Home",Action="AboutUs",Label="About Us"},
                    new MenuItems{ Controller = "Home",Action="ContactUs",Label="Contact Us"},
                    new MenuItems{ Controller = "Home",Action="Login",Label="Login"}
                });
               
            }
            return items.AsEnumerable();
        }
        [HttpGet("uoms")]
        public IEnumerable<DropDownItem> GetUOMs()
        {
            var measures = context.UOMs.Select(i => new DropDownItem { Text = i.Description, Value = i.UnitId.ToString() }).AsEnumerable();
            return measures;
        }
        [HttpGet("customerlist")]
        public IEnumerable<Customer> CustomersList()
        {
            var customers = context.Customers.AsEnumerable();
            return customers;
        }
        [HttpGet("customer/{id}")]
        public Customer CustomersList(int id)
        {
            var customers = context.Customers.Where(i=>i.CustomerId == id).FirstOrDefault();
            return customers;
        }

        [HttpPost("savecustomer")]
        public CommonMessage SaveCustomer(Customer customer)
        {
            CommonMessage message = new CommonMessage();
            try
            {
                if (ModelState.IsValid)
                {
                    var dupcus = context.Customers.Where(i => (i.FirstName == customer.LastName && i.LastName == i.LastName) || i.Email == customer.Email).FirstOrDefault();

                    if (dupcus == null)
                    {
                        context.Customers.Add(customer);
                        int i = context.SaveChanges();
                        if(i > 0)
                        {
                            message.Result = 1;
                            message.ErrorMessage = "Customer Saved.";
                        }
                        else
                        {
                            message.Result = -1;
                            message.ErrorMessage = "Please Contact Admin.";
                        }
                    }
                    else
                    {
                        message.Result = -1;
                        message.ErrorMessage = "Customer Already Exist.";
                    }
                }
                else
                {
                    message.Result = -2;
                    message.ErrorMessage = "Invalid Entry.";
                }
                return message;
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                message.Result = -3;
                message.ErrorMessage = "Something went wrong.";
                return message;
            }
        
        }
        [HttpPut("updatecustomer")]
        public CommonMessage UpdateCustomer(Customer customer)
        {
            CommonMessage message = new CommonMessage();
            try
            {
                if (ModelState.IsValid)
                {
                    var cus = context.Customers.Where(i => i.CustomerId == customer.CustomerId).FirstOrDefault();

                    if (cus != null)
                    {
                        cus.FirstName = customer.FirstName;
                        cus.LastName = customer.LastName;
                        cus.Email = customer.Email;
                        cus.MobileNumber = customer.MobileNumber;
                        cus.ModifiedOn = customer.ModifiedOn;
                        context.Customers.Update(cus);
                        int i = context.SaveChanges();
                        if (i > 0)
                        {
                            message.Result = 1;
                            message.ErrorMessage = "Customer Updated.";
                        }
                        else
                        {
                            message.Result = -1;
                            message.ErrorMessage = "Please Contact Admin.";
                        }
                    }
                    else
                    {
                        message.Result = -1;
                        message.ErrorMessage = "Customer Does Not Exist.";
                    }
                }
                else
                {
                    message.Result = -2;
                    message.ErrorMessage = "Invalid Entry.";
                }
                return message;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                message.Result = -3;
                message.ErrorMessage = "Something went wrong.";
                return message;
            }

        }
        [HttpDelete("deletecustomer")]
        public CommonMessage DeleteCustomer(Customer customer)
        {
            CommonMessage message = new CommonMessage();
            try
            {
                if (ModelState.IsValid)
                {
                    var cus = context.Customers.Where(i => (i.FirstName == customer.LastName && i.LastName == i.LastName) || i.Email == customer.Email).FirstOrDefault();

                    if (cus != null)
                    {
                        context.Customers.Remove(cus);
                        int i = context.SaveChanges();
                        if (i > 0)
                        {
                            message.Result = 1;
                            message.ErrorMessage = "Customer Deleted.";
                        }
                        else
                        {
                            message.Result = -1;
                            message.ErrorMessage = "Please Contact Admin.";
                        }
                    }
                    else
                    {
                        message.Result = -1;
                        message.ErrorMessage = "Customer Does Not Exist.";
                    }
                }
                else
                {
                    message.Result = -2;
                    message.ErrorMessage = "Invalid Entry.";
                }
                return message;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                message.Result = -3;
                message.ErrorMessage = "Something went wrong.";
                return message;
            }
        }
    }
}
