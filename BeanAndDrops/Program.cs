using Microsoft.EntityFrameworkCore;
using BeanAndDrops.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Connect to Database 
builder.Services.AddDbContextPool<AppDbContext>(options =>
	   options.UseMySQL(builder.Configuration.GetConnectionString("Defaults")));

// for use SSMS we use UseSqlServer method rather UseMySQL

//prepare Cookies
CookieOptions cookieOptions = new CookieOptions();
cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(1));


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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
