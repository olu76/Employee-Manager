
using System.IO;
using System.Buffers;
using EmployeeManager.Models;
using EmployeeManager.MVC.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
                        .AddRazorPagesOptions(options =>
                        {
                            options.Conventions.AddPageRoute("/EmployeeManager/List", "");
                        });



 builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer
(ConnectionString));

builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer
(ConnectionString));
builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.ConfigureApplicationCookie(Options =>
{
                            Options.LoginPath = "/Security/SignIn";
                            Options.AccessDeniedPath ="/Security/AccessDenies";
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeManager}/{action=List}/{id?}");
   app.UseEndpoints(endpoints =>
   {
       endpoints.MapRazorPages();
   });

app.Run();
