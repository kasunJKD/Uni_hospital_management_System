using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;
using Uni_hospital.Repositories;

namespace Uni_hospital.Utilities
{
    public class DbInitializer: IDbInitializer
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        

        public async void Initialize()
        {
            var SpecialitySeed = new Speciality[]
            {
                new Speciality { Id=1, Name = "Patient", Description="Patient" },
                new Speciality { Id=2, Name = "Cardio", Description="Cardio" },
                new Speciality { Id=3, Name = "Special2",Description= "Special2" },
                // Add more products
            };


            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {

                throw;
            }
/*            if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin@gmail.com",
                    Email = "Admin@gmail.com"
                }, "Admin").GetAwaiter().GetResult();
                var Appuser = _context.Users.FirstOrDefault(x => x.Email == "Admin@gmail.com");
                if (Appuser != null)
                {
                    _userManager.AddToRoleAsync(Appuser, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
                }
            }*/

            //seeding to tables
            _context.Database.EnsureCreated(); // Ensure database is created
            _context.Database.Migrate(); // Apply pending migrations

            // Seed data
            if (!_context.Speciality.Any())
            {
                _context.Speciality.AddRange(SpecialitySeed);
                _context.SaveChanges();
            }
            // Create Identity users



            try
            {
                var user1 = new ApplicationUser
                {
                    Email = "Admin@gmail.com",
                    UserName = "Admin",
                    SpecialityId = null,
                };
                
                _userManager.CreateAsync(user1, "Mate1234!").GetAwaiter().GetResult();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
