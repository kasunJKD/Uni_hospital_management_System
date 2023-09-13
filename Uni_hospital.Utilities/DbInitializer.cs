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
                new Tips { Id=2, Description="Contact reception for more details about doctors", CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
            };

            var MedsSeed = new Medicine[]
            {
                new Medicine { Id=1, Description="potent tranquilizer of moderate duration within the triazolobenzodiazepine", Name="Amoxicillin ", Type="aminopenicillin", Cost=12,  },
                 new Medicine { Id=2, Description="treat bacterial infections", Name="Alprazolam", Type="Xanax", Cost=10,  },
                  new Medicine { Id=3, Description="calcium channel blocker medication", Name="Amlodipine", Type="Norvasc", Cost=12,  },
                   new Medicine { Id=4, Description="used to treat epilepsy", Name="Pregabalin", Type="Lyrica", Cost=29,  },
                    new Medicine { Id=5, Description="used to treat fluid build-up due to heart failure", Name="Spironolactone", Type="Aldactone", Cost=32,  },
                     new Medicine { Id=6, Description="COX-2 inhibitor and nonsteroidal anti-inflammatory drug", Name="Celecoxib", Type="Celebrex", Cost=30,  },
                      new Medicine { Id=7, Description="antibiotic that can treat a number of bacterial infections", Name="Cefalexin", Type="cephalexin", Cost=12,  },
                       new Medicine { Id=8, Description="is a medication used in the treatment of gastroesophageal reflux disease", Name="Omeprazole", Type="Prilosec", Cost=12,  },
                        new Medicine { Id=9, Description="is an antidepressant of the selective serotonin reuptake inhibitor class.", Name="Escitalopram", Type="Lexapro", Cost=12,  },
                         new Medicine { Id=10, Description="treat major depressive disorder, generalized anxiety disorder", Name="Duloxetine", Type="Cymbalta", Cost=12,  },
                          new Medicine { Id=11, Description=" nonsteroidal anti-inflammatory drug that is used to relieve pain, fever, and inflammation. This includes painful menstrual periods", Name="Ibuprofen", Type="Ibuprofen", Cost=12,  },
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
            if (!_context.Medicine.Any())
            {
                _context.Medicine.AddRange(MedsSeed);
                _context.SaveChanges();
            }
            // Create Identity users
            var user1 = new ApplicationUser
            {
                Email = "Doctor1@gmail.com",
                UserName = "Wasantha",
                FirstName = "Sarath",
                LastName = "Gunathilake",
                SpecialityId = 4,
                IsDoctor=true,
            };

            _userManager.CreateAsync(user1, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity users
            var user2 = new ApplicationUser
            {
                Email = "Doctor2@gmail.com",
                UserName = "Wasantha",
                FirstName = "Wasantha",
                LastName = "Rathnayake",
                SpecialityId = 3,
                IsDoctor = true,
            };

            _userManager.CreateAsync(user2, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity patient
            var user3 = new ApplicationUser
            {
                Email = "Patient1@gmail.com",
                UserName = "Patient1@gmail.com",
                FirstName = "Kanthi",
                LastName = "Perera",
                IsDoctor = false,
                SpecialityId = 2,
            };

            _userManager.CreateAsync(user3, "Mate1234!").GetAwaiter().GetResult();

            // Create Identity patient
            var user4 = new ApplicationUser
            {
                Email = "Mahendra@gmail.com",
                UserName = "Mahendra@gmail.com",
                FirstName = "Mahendra",
                LastName = "Perera",
                IsDoctor = true,
                SpecialityId = 6,
            };

            _userManager.CreateAsync(user4, "Mate1234!").GetAwaiter().GetResult();

            // Create Identity patient
            var user5 = new ApplicationUser
            {
                Email = "Priyantha@gmail.com",
                UserName = "Priyantha",
                FirstName = "Priyantha",
                LastName = "Madawala",
                IsDoctor = true,
                SpecialityId = 2,
            };

            _userManager.CreateAsync(user5, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity patient
            var user6 = new ApplicationUser
            {
                Email = "Jayatilake@gmail.com",
                UserName = "Jayatilake",
                FirstName = "R.S",
                LastName = "Jayatilake",
                IsDoctor = true,
                SpecialityId = 2,
            };

            _userManager.CreateAsync(user6, "Mate1234!").GetAwaiter().GetResult();



            // Create Identity patient
            var user7 = new ApplicationUser
            {
                Email = "Jayasekara@gmail.com",
                UserName = "Jayasekara",
                FirstName = "Panduka",
                LastName = "Jayasekara",
                IsDoctor = true,
                SpecialityId = 2,
            };

            _userManager.CreateAsync(user7, "Mate1234!").GetAwaiter().GetResult();



            // Create Identity patient
            var user8 = new ApplicationUser
            {
                Email = "Gunasekara@gmail.com",
                UserName = "Gunasekara",
                FirstName = "Dehan",
                LastName = "Gunasekara",
                IsDoctor = true,
                SpecialityId = 5,
            };

            _userManager.CreateAsync(user8, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity patient
            var user9 = new ApplicationUser
            {
                Email = "Goonatillake@gmail.com",
                UserName = "Goonatillake",
                FirstName = "Shama",
                LastName = "Goonatillake",
                IsDoctor = true,
                SpecialityId = 2,
            };

            _userManager.CreateAsync(user9, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity patient
            var user10 = new ApplicationUser
            {
                Email = "Patient1@gmail.com",
                UserName = "Patient1@gmail.com",
                FirstName = "Kanthi",
                LastName = "Perera",
                IsDoctor = true,
                SpecialityId = 2,
            };

            _userManager.CreateAsync(user10, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity patient
            var user11 = new ApplicationUser
            {
                Email = "Ekanayake@gmail.com",
                UserName = "Upul",
                FirstName = "Upul",
                LastName = "Ekanayake",
                IsDoctor = true,
                SpecialityId = 7,
            };

            _userManager.CreateAsync(user11, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity patient
            var user12 = new ApplicationUser
            {
                Email = "Ariyarathna@gmail.com",
                UserName = "Ariyarathna",
                FirstName = "Yasantha",
                LastName = "Ariyarathna",
                IsDoctor = false,
                SpecialityId = 4,
            };

            _userManager.CreateAsync(user12, "Mate1234!").GetAwaiter().GetResult();


            // Create Identity patient
            var user13 = new ApplicationUser
            {
                Email = "Abeysinghe@gmail.com",
                UserName = "Prasad",
                FirstName = "Prasad",
                LastName = "Abeysinghe",
                IsDoctor = false,
                SpecialityId = 3,
            };

            _userManager.CreateAsync(user13, "Mate1234!").GetAwaiter().GetResult();


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
