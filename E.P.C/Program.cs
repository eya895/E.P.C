using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using E.P.C.Data;
using E.P.C.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ShoppingCartService>();

// Add MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// ===================== DATABASE =====================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ===================== IDENTITY =====================
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// ===================== SESSION (ADDED - REQUIRED FOR PC BUILDER) =====================
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2); // keeps build alive longer
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Dummy email sender so Identity works without real SMTP
builder.Services.AddSingleton<IEmailSender, DummyEmailSender>();

var app = builder.Build();

// ===================== SEED ADMIN =====================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbInitializer.SeedAdminAsync(services);
}

// ===================== PIPELINE =====================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ===================== SESSION (MUST BE HERE) =====================
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

// ===================== ROUTES =====================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

// ===================== DUMMY EMAIL =====================
public class DummyEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }
}