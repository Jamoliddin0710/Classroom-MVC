using Classroom_Task_11._11._22.Context;
using Classroom_Task_11._11._22.Entity;
using Classroom_Task_11._11._22.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<User, UserRole>(option =>
{
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireDigit = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
    option.Password.RequiredLength = 6;
})
 .AddEntityFrameworkStores<UserDbContext>();
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlite("Data source = data.db");
});
builder.Services.Configure<JsonData>(builder.Configuration.GetSection("JsonData"));
// appsettings.josndan keyni olish uchun
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
    pattern: "{controller=Account}/{action=SignUp}");

app.Run();
