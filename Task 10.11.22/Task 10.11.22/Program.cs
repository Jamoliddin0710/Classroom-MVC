using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task_10._11._22.Context;
using Task_10._11._22.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlite("Data source=users.db");

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    
    options => {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;

    }).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddCors(option =>
{
    option.AddPolicy("All", cors => cors.AllowAnyHeader()
    .AllowAnyOrigin().AllowAnyMethod());
    option.AddPolicy("Front", cors =>
    cors.WithHeaders("Server").
    WithOrigins(" http://localhost:5031").
    WithMethods("get","put","post"));
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("SignInUser", policyoption =>
    {
        policyoption.RequireClaim("UserAge");
    });
  

    option.AddPolicy("GetUser", policyoption =>
    policyoption.RequireRole("Admin"));
});




/*builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("SignInUser", policyoption =>
    {
        policyoption.RequireClaim("UserAge").RequireClaim("IsActive").RequireRole("Admin");
    });
    option.AddPolicy("GetUsers", policyoption =>
    {
        policyoption.RequireAssertion((context) =>
        {
            var isUserAge = false;
           if(int.TryParse(context.User.FindFirst("UserAge").Value, out var userage))
            {
                isUserAge = userage > 20;
            }
          return  context.User.HasClaim(C => C.Type == "Admin" || isUserAge);
     });

    });
});*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Front");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
