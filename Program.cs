//After Adding the session to my project

using BookingSystem.DataAccess.Data;
using BookingSystem.DataAccess.DbInitializer;
using BookingSystem.DataAccess.Repository;
using BookingSystem.DataAccess.Repository.IRepository;
using BookingSystem.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Session configuration
builder.Services.AddDistributedMemoryCache(); // Use an in-memory cache for session storage
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjust the session timeout as needed
});

// Identity and authentication configurations
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Identity/Account/Login";
	options.LogoutPath = "/Identity/Account/Logout";
	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

// Configure the HTTP request pipeline.
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Add session middleware
app.UseSession();

SeedDatabase();

string key = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
StripeConfiguration.ApiKey = key;

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();

void SeedDatabase()
{
	using (var scope = app.Services.CreateScope())
	{
		var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
		dbInitializer.Initialize();
	}
}
