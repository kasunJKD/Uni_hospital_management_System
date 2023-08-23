using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;

namespace Uni_hospital.Repositories
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<PrescribedMedicine> PrescribedMedicine { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<MedicineReport> MedicineReport { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<LabResults> LabResults { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Tips> Tips { get; set; }
    }
}
