using Coursework1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Controllers
{
    public static class DbInitializer
    {
        
        public static void Initialize (AppDataContext context,UserManager<ApplicationUser> userManager)
        {
            CreateUsers(context, userManager);
            CreateCustomers(context, userManager);
        }


        private static async void CreateUsers(AppDataContext context, UserManager<ApplicationUser> userManager)
        {
            Task<ApplicationUser> seededUser = userManager.FindByEmailAsync("Member1@email.com");
            seededUser.Wait();

            if (seededUser.Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "Member1@email.com",
                    Email = "Member1@email.com",
                };
                var create = await userManager.CreateAsync(user, "Password123!");
              

            }
            
          

        }

        private static async void CreateCustomers(AppDataContext context, UserManager<ApplicationUser> userManager)
        {
            List<string> customers = SetupCustomerList();

            foreach(var cust in customers)
            {
                var seededUser = await userManager.FindByEmailAsync(cust);
               

                if (seededUser == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        UserName = cust,
                        Email = cust,
                    };
                    var create = await userManager.CreateAsync(user, "Password123!");
                    
                }
            }

        }

        private static List<string> SetupCustomerList()
        {
            List<string> customers = new List<string>();
            customers.Add("Customer1@email.com");
            customers.Add("Customer2@email.com");
            customers.Add("Customer3@email.com");
            customers.Add("Customer4@email.com");
            customers.Add("Customer5@email.com");

            return customers;
        }

    }
}
