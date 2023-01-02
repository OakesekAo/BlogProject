using BlogProject.Data;
using BlogProject.Enums;
using BlogProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;


        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            //Task: Create the DB from the Migrations
            await _dbContext.Database.MigrateAsync();

            //1. Seeding a few Roles into the system
            await SeedRolesAsync();

            //2. Seed a few user into the system
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //if there are already Roles in the system, do nothing.
            if (_dbContext.Roles.Any()) return;

            //Otherwise we want to create a few Roles
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }


        }

        private async Task SeedUsersAsync()
        {
            //if there are already User in the system, do nothing.
            if (_dbContext.Users.Any())
            {
                return;

            }

            //Step 1. Creates a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "oakes.a@live.com",
                UserName = "oakes.a@live.com",
                FirstName = "Andrew",
                LastName = "Oakes",
                DisplayName = "AdminOakes",
                PhoneNumber = "1234567890",
                EmailConfirmed = true
            };

            //Step 2. Use the UserManager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step 3. Add this new user to the Administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //Step 1 repeat: Create the moderator user
            var modUser = new BlogUser()
            {
                Email = "dr_whooo@msn.com",
                UserName = "ModOakes",
                FirstName = "Andrew",
                LastName = "Oakes",
                DisplayName = "ModOakes",
                PhoneNumber = "1234567890",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(modUser, "Abc&123!");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }





    }
}
