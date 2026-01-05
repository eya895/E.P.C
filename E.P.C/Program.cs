using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using E.P.C.Data;
using Microsoft.AspNetCore.Identity.UI.Services; // for IEmailSender
using E.P.C.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Needed for Identity UI

// Configure your DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure ASP.NET Core Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // no email confirmation for testing
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// ? Add a dummy email sender so Register works
builder.Services.AddSingleton<IEmailSender, DummyEmailSender>();
builder.Services.AddScoped<ShoppingCartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication & Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map controllers and Razor Pages
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Required for Identity UI

app.Run();


// Dummy email sender implementation
public class DummyEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Do nothing - just satisfies the dependency
        return Task.CompletedTask;
    }
}


