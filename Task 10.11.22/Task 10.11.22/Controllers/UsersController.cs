
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task_10._11._22.Service;

namespace Task_10._11._22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp(UserDto userDto)
        {
            if(userDto.UserName is null)
            return BadRequest("usename nullga teng"); 

                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    var role = new IdentityRole("Admin");
                    await _roleManager.CreateAsync(role);
                }
            
            var user = new IdentityUser()
            {                   
                Id = userDto.Id,
                UserName = userDto.UserName,
                Email = userDto.Email,           
            };
            var creted  = await _userManager.CreateAsync(user, "asnd34empsd23402");

            if (!creted.Succeeded) { return Ok("Not Added "); }
            await _userManager.AddToRoleAsync(user, "Admin");

            await _userManager.AddClaimsAsync(user, new List<Claim>
            {
                new Claim("UserAge", "23"),
                new Claim("UserRole","user"),
                new Claim("IsActive","false")

            });

            await _signInManager.SignInAsync(user, isPersistent: true);

            return Ok(user);
        }

        [HttpGet("user")]
        [Authorize(Policy = "SignInUser")]
        public async Task<IActionResult> SignIn(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                return NotFound("User topilmadi");

            return Ok(user);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(_userManager.Users.ToList());
        }
    }
}
