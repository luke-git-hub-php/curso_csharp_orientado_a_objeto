using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NaniWeb.Services;

namespace NaniWeb.Controllers
{
    [Authorize]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly EmailSender _emailSender;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public AuthenticationController(IConfiguration configuration, SignInManager<IdentityUser<Guid>> signInManager, UserManager<IdentityUser<Guid>> userManager, EmailSender emailSender)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn([FromQuery] string originPath)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("YourProfile", "User");

            if (!string.IsNullOrWhiteSpace(originPath))
                ViewData["OriginPath"] = originPath;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromForm] string email, [FromForm] string password, [FromForm] string originPath)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("YourProfile", "User");

            var errors = new List<string>();
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null && (await _signInManager.PasswordSignInAsync(user, password, false, true)).Succeeded)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, true);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrWhiteSpace(originPath))
                        return Redirect(originPath);
                    
                    return RedirectToAction("YourProfile", "User");
                }

                if (result.IsLockedOut)
                    errors.Add("You're not allowed to sign in due to too many invalid sign in attempts.");

                if (result.IsNotAllowed)
                    errors.Add("You're not allowed to sign in because the administrator disabled your account.");
            }
            else
            {
                errors.Add("Invalid credentials. Please check your email and password.");
            }

            TempData["Errors"] = errors.ToArray();

            return RedirectToAction("SignIn");
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("YourProfile", "User");

            if (!_configuration.GetValue<bool>("Email:Enabled"))
                return RedirectToAction("SignIn");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromForm] string email)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("YourProfile", "User");

            if (!_configuration.GetValue<bool>("Email:Enabled"))
                return RedirectToAction("SignIn");

            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var siteName = _configuration.GetValue<string>("Web:SiteName");
                var siteAddress = _configuration.GetValue<string>("Web:SiteAddress");
                var urlToAction = Url.Action("ChangePassword", new {userId = user.Id, token = await _userManager.GeneratePasswordResetTokenAsync(user)});
                var message = new StringBuilder();
                var htmlMessage = new StringBuilder();

                message.AppendLine($"Hello {user.UserName}!");
                message.AppendLine();
                message.AppendLine($"A password reset was requested to your {siteName} account.");
                message.AppendLine($"If you didn't request a password reset you can safely ignore this message, otherwise click here: {siteAddress}{urlToAction}");

                htmlMessage.AppendLine($"Hello {user.UserName}!<br>");
                htmlMessage.AppendLine("<br>");
                htmlMessage.AppendLine($"A password reset was requested to your {siteName} account.<br>");
                htmlMessage.AppendLine($"If you didn't request a password reset you can safely ignore this message, otherwise click <a href=\"{siteAddress}{urlToAction}\">here</a>.");

                await _emailSender.SendEmail(_configuration.GetValue<string>("Web:EmailAddress"), user.Email, $"{siteName} Password Reset", message.ToString(), htmlMessage.ToString());
            }

            TempData["SuccessMessage"] = "A message with the information on how to reset your password was sent to the specified email.";

            return RedirectToAction("SignIn");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromQuery] Guid userId, string token)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("YourProfile", "User");

            if (!_configuration.GetValue<bool>("Email:Enabled"))
                return RedirectToAction("SignIn");

            if (token != null && await _userManager.FindByIdAsync(userId.ToString()) != null)
                return View(new Tuple<Guid, string>(userId, token));

            TempData["Errors"] = new[] {"Invalid credentials. Please try again or contact an administrator."};

            return RedirectToAction("SignIn");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromForm] Guid userId, [FromForm] string token, [FromForm] string password)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("YourProfile", "User");

            if (!_configuration.GetValue<bool>("Email:Enabled"))
                return RedirectToAction("SignIn");

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (token != null && user != null && !string.IsNullOrWhiteSpace(password))
            {
                var result = await _userManager.ResetPasswordAsync(user, token, password);

                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Your password was reset. You can now sign in.";

                    RedirectToAction("SignIn");
                }
            }

            TempData["Errors"] = new[] {"Invalid credentials. Please try again or contact an administrator."};

            return RedirectToAction("SignIn");
        }
    }
}