using DeviceManagerAPI.Data;
using DeviceManagerAPI.DTO;
using DeviceManagerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagerAPI.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DataContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, DataContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            var response = new UserLoginDTO();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login (UserLoginDTO userToCreate)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //user is found. Check password
            var user = await _userManager.FindByEmailAsync(userToCreate.Email);

            if(user == null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, userToCreate.Password);
                if(passwordCheck)
                {
                    //password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, userToCreate.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                //password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again.";
                return View(userToCreate);

            }

            //user not found
            TempData["Error"] = "Wrong credentials. Please try again.";
            return View(userToCreate);
           
        }
    }
}
