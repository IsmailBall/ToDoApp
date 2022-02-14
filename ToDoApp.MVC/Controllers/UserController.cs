using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoApp.MVC.Model;
using ToDoApp.MVC.Security;

namespace ToDoApp.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;


        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult SignIn(string? returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View(new UserSignInModel());
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel userSignInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(userName: userSignInModel.Username, password: userSignInModel.Password, userSignInModel.RememberMe, false);
            if (result.Succeeded)
            {
                await _roleManager.CreateAsync(new AppRole
                {
                    CreationTime = System.DateTime.Now,
                    Name = "Member",
                });
                var currentUser = await _userManager.FindByNameAsync(userSignInModel.Username);
                if (!await _userManager.IsInRoleAsync(currentUser,"Member"))
                {
                    await _userManager.AddToRoleAsync(currentUser, "Member");
                }
                
                return Redirect(TempData["returnUrl"] as string);
            }
            else if (result.IsNotAllowed)
            {

            }
            else if(result.IsLockedOut)
            {

            }
            return RedirectToAction("SignIn");
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View(new UserLogInModel());
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserLogInModel userLogInModel)
        {
            AppUser user = new()
            {
                Email = userLogInModel.Email,
                UserName = userLogInModel.Username,
                Gender = userLogInModel.Gender
            };
            var result = await _userManager.CreateAsync(user, userLogInModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("GetList", "Home");
            }
            return RedirectToAction("LogIn");
        }
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "User");
        }
    }
}
