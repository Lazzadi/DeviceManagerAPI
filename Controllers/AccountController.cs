using DeviceManagerAPI.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[HttpPost]
public async Task<IActionResult> Login(UserLoginDTO userToLogin)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    //user is found. Check password
    var user = await _userManager.FindByEmailAsync(userToLogin.Email);

    if (user != null)
    {
        var passwordCheck = await _userManager.CheckPasswordAsync(user, userToLogin.Password);
        if (passwordCheck)
        {
            //password correct, sign in
            var result = await _signInManager.PasswordSignInAsync(user, userToLogin.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        //password is incorrect
        TempData["Error"] = "Wrong credentials. Please try again.";
        return View(userToLogin);

    }

    //user not found
    TempData["Error"] = "Wrong credentials. Please try again.";
    return View(userToLogin);

}