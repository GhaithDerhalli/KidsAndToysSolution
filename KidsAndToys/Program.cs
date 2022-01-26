
using KidsAndToys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<UsersService>();
var connString = builder.Configuration
    .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IdentityDbContext>(
    o => o.UseSqlServer(connString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(
    o => o.LoginPath = "/login");

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error/exception");
    app.UseStatusCodePagesWithRedirects("/error/http/{0}");
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(o => o.MapControllers());


app.Run();