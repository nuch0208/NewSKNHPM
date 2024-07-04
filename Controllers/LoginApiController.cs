using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SKNHPM.Models;
using SKNHPM.ViewModels;

namespace SKNHPM.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class LoginApiController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public LoginApiController(SignInManager<AppUser> signInManager , UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            // ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //login
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);

                if (result.Succeeded)
                {
                    // return RedirectToLocal(returnUrl);
                    return RedirectToAction("Index","Home");
                }

                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }

        public IActionResult Registar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registar(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    Address = model.Address
                };
                var result = await userManager.CreateAsync(user,model.Password!);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);

                        // return RedirectToLocal(returnUrl);
                        return RedirectToAction("Index","Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
            }
            return View();
        }
       public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}