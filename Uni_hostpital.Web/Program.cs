using Uni_hospital.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Uni_hospital.Utilities;
using Uni_hospital.Repositories.Interfaces;
using Uni_hospital.Repositories.Implementations;
using Microsoft.AspNetCore.Identity.UI.Services;
using Uni_hospital.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();
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
app.MapControllerRoute(
    name: "default",
    pattern: "{Area=Patient}/{controller=Home}/{action=Index}/{id?}");

app.Run();

void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbIntializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbIntializer.Initialize();
    }
}
