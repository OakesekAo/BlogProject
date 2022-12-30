using BlogProject.Data;
using BlogProject.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public async Task ManageDataAsync()
        {
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
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }


        }

        private async Task SeedUsersAsync()
        {

        }





    }
}
