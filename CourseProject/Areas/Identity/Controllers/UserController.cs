using CourseProject.Areas.Identity.Data;
using CourseProject.Models;
using CourseProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CourseProject.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class UserController : Controller
    {
        private UserManager<AddFieldToUser> _userManager;
        private SignInManager<AddFieldToUser> _signInManager;
        private IEmailSender _emailSender;

        public UserController(UserManager<AddFieldToUser> userManager, SignInManager<AddFieldToUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userInfo, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(userInfo.UserName, userInfo.Password, false, false);

                if (result.Succeeded)
                {
                    return Redirect(returnUrl);
                }
                else if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Please Confirm your account first.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Log In attempt. Password or Username incorrect.");
                }
            }

            return View(userInfo);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Users user, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                AddFieldToUser identityUser = new AddFieldToUser { UserName = user.UserName, Email = user.Email};
                IdentityResult result = await _userManager.CreateAsync(identityUser, user.Password);

                if (result.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(identityUser);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.PageLink(
                        values: new { area = "Identity", action = "confirmEmail", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    return Redirect(returnUrl);
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(user);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (userId == null || code == null)
            {
                return Redirect(returnUrl);
            }

            AddFieldToUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            string statusMessage = result.Succeeded ? "Thank you confirm your account." : "Error confirming your account.";
            
            return View("ConfirmEmail", statusMessage);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
