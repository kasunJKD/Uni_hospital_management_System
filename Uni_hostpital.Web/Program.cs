using Uni_hospital.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Uni_hospital.Utilities;
using Uni_hospital.Repositories.Interfaces;
using Uni_hospital.Repositories.Implementations;
using Microsoft.AspNetCore.Identity.UI.Services;
using Uni_hospital.Services;
using Uni_hospital.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IAvailablityService, AvailabilityService>();
builder.Services.AddTransient<ISpecialityService, SpecialityService>();
builder.Services.AddTransient<ITipsService, TipsService>();
builder.Services.AddTransient<IMedicineService, MedicineService>();
builder.Services.AddTransient<IFeedBackService, FeedBackService>();
builder.Services.AddTransient<IPrescribedMedicineService, PrescribedMedicineService>();
builder.Services.AddTransient<IPatientReportService, PatientReportService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
DataSeeding();
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{Area=Admin}/{controller=Home}/{action=Index}/{id?}");*/

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Default route for users with the "admin" role
/*app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists=Admin}/{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "Admin" },
    constraints: new { area = "Admin", role = "Admin" }
);

// Default route for users with the "doctor" role
app.MapControllerRoute(
    name: "Patient",
    pattern: "{area:exists=Patient}/{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "Patient" },
    constraints: new { area = "Patient", role = "Patient" }
);*/

// Default route for other users or unauthenticated users
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);*/


app.Run();

void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbIntializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbIntializer.Initialize();
    }
}
