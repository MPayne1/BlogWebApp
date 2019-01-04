using Coursework1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Coursework1.Controllers
{
    public static class DbInitializer
    {
        // Role strings
        public static readonly string canPostRole = "canPost";
        private static readonly string canCommentRole = "canComment";
        private static readonly string canDeletePostRole = "canDeletePost";
        private static readonly string canDeleteCommentRole = "canDeleteComment";

        private static IServiceProvider serviceProvider;
        private static UserManager<ApplicationUser> userManager;
        private static AppDataContext context;

        public static async Task Initialize (AppDataContext _context, UserManager<ApplicationUser> _userManager, IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
            userManager = _userManager;
            context = _context;

            await CreateUsers();
            await CreateCustomers();
        }

        // Create users if not already in db, with roles
        private static async Task CreateUsers()
        {
            var seededUser = await userManager.FindByEmailAsync("Member1@email.com");
       
            if (seededUser == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "Member1@email.com",
                    Email = "Member1@email.com",
                };
                var create = await userManager.CreateAsync(user, "Password123!");
                await CreateRoles(user.Id, canPostRole);
                await CreateRoles(user.Id, canDeletePostRole);
                await CreateRoles(user.Id, canDeleteCommentRole);
            }
            
        }

        // Create customer if not already in db, with roles
        private static async Task CreateCustomers()
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
                    await CreateRoles(user.Id, canCommentRole);
                }
            }

        }

        // create roles if !exist
        private static async Task CreateRoles(string id, string role)
        {

            IdentityResult identityResult = null;
            
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if(roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if(!await roleManager.RoleExistsAsync(role))
            {
                identityResult = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByIdAsync(id);

            var isinRole = await userManager.IsInRoleAsync(user, role);
            if(!isinRole)
            {
                identityResult = await userManager.AddToRoleAsync(user, role);
            }
            
        }


        // list of customers 
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
