using DataAccessLayer.DBContext;
using DataAccessLayer.Respository;
using DataAccessLayer.Respository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Identity;
using UtilityLayer;
using Microsoft.AspNetCore.Identity.UI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitofwork, Unitofwork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDBContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyDBContext>().AddDefaultTokenProviders();
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
