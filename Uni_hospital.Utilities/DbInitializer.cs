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

        

        public void Initialize()
        {
            var SpecialitySeed = new Speciality[]
            {
                new Speciality { Id=1, Name = "Any", Description="Any" },
                new Speciality { Id=2, Name = "Aesthetic Physician", Description="Aesthetic Physician" },
                new Speciality { Id=3, Name = "Allergy And Immunology",Description= "Allergy And Immunology" },
                new Speciality { Id=4, Name = "Anaesthetist",Description= "Anaesthetist" },
                new Speciality { Id=5, Name = "Applied Psychologist",Description= "Applied Psychologist" },
                new Speciality { Id=6, Name = "Audiologist",Description= "Audiologist" },
                new Speciality { Id=7, Name = "Cardiologist",Description= "Cardiologist" },
                new Speciality { Id=8, Name = "Gynaecologist",Description= "Gynaecologist" },
                new Speciality { Id=9, Name = "Bacteriologist",Description= "Bacteriologist" },
                new Speciality { Id=10, Name = "Breast and Cancer Surgeon",Description= "Breast and Cancer Surgeon" },
            };

            var TipsSeed = new Tips[]
            {
                new Tips { Id=1, Description="Make sure to wash your hands", CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
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
            if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    Email = "Admin@gmail.com",
                    UserName = "Admin@gmail.com",
                    SpecialityId = null,
                }, "Mate1234!").GetAwaiter().GetResult();
                var Appuser = _context.Users.FirstOrDefault(x => x.Email == "Admin@gmail.com");
                if (Appuser != null)
                {
                    _userManager.AddToRoleAsync(Appuser, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
                }
            }

            //seeding to tables
            _context.Database.EnsureCreated(); // Ensure database is created
            _context.Database.Migrate(); // Apply pending migrations

            // Seed data
            if (!_context.Speciality.Any())
            {
                _context.Speciality.AddRange(SpecialitySeed);
                _context.SaveChanges();
            }

            if (!_context.Tips.Any())
            {
                _context.Tips.AddRange(TipsSeed);
                _context.SaveChanges();
            }
            // Create Identity users
            var user1 = new ApplicationUser
            {
                Email = "Doctor1@gmail.com",
                UserName = "Doctor1",
                FirstName = "Doctor1",
                LastName = "Doctor1LastName",
                SpecialityId = 2,
                IsDoctor=true,
            };

            _userManager.CreateAsync(user1, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity users
            var user2 = new ApplicationUser
            {
                Email = "Doctor2@gmail.com",
                UserName = "Doctor2",
                FirstName = "Doctor2",
                LastName = "Doctor2LastName",
                SpecialityId = 3,
                IsDoctor = true,
            };

            _userManager.CreateAsync(user2, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity patient
            var user3 = new ApplicationUser
            {
                Email = "Patient1@gmail.com",
                UserName = "Patient1",
                FirstName = "Patient1",
                LastName = "PLastName1",
                IsDoctor = false,
                SpecialityId = 1,
            };

            _userManager.CreateAsync(user3, "Mate1234!").GetAwaiter().GetResult();


            //debug lines
            /* try
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
             }*/
        }
    }
}
