using Classroom_Task_11._11._22.Entity;
using Classroom_Task_11._11._22.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Classroom_Task_11._11._22.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<UserRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly string Key;
        public AccountController(IOptions<JsonData> options, UserManager<User> userManager, RoleManager<UserRole> roleManager, SignInManager<User> signInManager)
        {
            Key = options.Value.Key;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public IActionResult SignUp(UserLogin? userLogin)
        {

            return View();
        }



        public IActionResult SignIn()
        {

            return View();
        }
        public async Task<IActionResult> Index(UserLogin userLogin)
        {
            if (userLogin.Password != userLogin.ConfirmPassword)
            {
                return BadRequest("Parolni tasdiqlashda  xatolik");
            }
            var aboutpassword = userLogin.Password.Length > 7;
            var user = new User()
            {
                UserName = userLogin.UserName,
                Email = userLogin.Email,
                PasswordHash = userLogin.Password,
                PhoneNumber = userLogin.PhoneNumber,

            };
            var created = await userManager.CreateAsync(user, Key);

            if (!created.Succeeded)
            {
                ModelState.AddModelError("Email","Ro'yxatga olishda xatolik");
                return BadRequest();
            }

            await userManager.AddClaimsAsync(user, new List<Claim>()
            {
                new Claim("Password",$"{userLogin.Password.Length>7}"),
                new Claim("Phone",$"{!int.TryParse(userLogin.PhoneNumber,out int _)}"),
            });
            await signInManager.SignInAsync(user, isPersistent: true);
            

            return View(user);
        }
    }
}
