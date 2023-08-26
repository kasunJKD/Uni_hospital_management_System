using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Models;

namespace Uni_hospital.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Appointment>()
                    .HasOne(p => p.Doctor)
                    .WithMany()
                    .HasForeignKey(p => p.DoctorId);
            modelBuilder.Entity<Appointment>()
                    .HasOne(p => p.Patient)
                    .WithMany()
                    .HasForeignKey(p => p.PatientId);
            modelBuilder.Entity<PatientReport>()
                   .HasOne(p => p.Doctor)
                   .WithMany()
                   .HasForeignKey(p => p.DoctorId);
            modelBuilder.Entity<PatientReport>()
                   .HasOne(p => p.Patient)
                   .WithMany()
                   .HasForeignKey(p => p.PatientId);
            modelBuilder.Entity<Availability>()
                   .HasOne(p => p.Doctor)
                   .WithMany(u => u.Availabilities)
                   .HasForeignKey(p => p.DoctorId);
            modelBuilder.Entity<Feedback>()
                   .HasOne(p => p.User)
                   .WithMany(u => u.Feedbacks)
                   .HasForeignKey(p => p.UserId);


        }

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
