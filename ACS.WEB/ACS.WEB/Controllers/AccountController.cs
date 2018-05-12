﻿//#warning закомментить notWindowsAuth
//#define notWindowsAuth
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ACS.WEB.Models;
using System.Collections.Generic;
using ACS.BLL.Interfaces;
using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.WEB.Models.ActiveDirectoryAuthentication;
using System.Security.Principal;
using ACS.BLL;

namespace ACS.WEB.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private IAccountAppUserService AccountAppUserService
        {
            get
            {
                //Поскольку ранее мы зарегитрировали сервис пользователей через контекст OWIN,
                //то теперь мы можем получить этот сервис с помощью метода
                return HttpContext.GetOwinContext().GetUserManager<IAccountAppUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public async Task<ActionResult> Login(string returnUrl)
        {
            string currentUserEmail = this.User.Identity.Name;

            var Users = AccountAppUserService.GetUsers().ToList();
             var appUser = (from user in Users                            where user.Email == currentUserEmail                            select user).FirstOrDefault();              if (appUser == null)
            {
                ViewBag.ReturnUrl = returnUrl;

                RegisterViewModel regVM = new RegisterViewModel() { Email = currentUserEmail, UserName = currentUserEmail };

                if (!string.IsNullOrEmpty(currentUserEmail) && !string.IsNullOrEmpty(regVM.Password))
                    return await this.Register(regVM);

            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
#if notWindowsAuth
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                ApplicationUserDTO applicationUserDTO = new ApplicationUserDTO { Email = model.Email, PasswordHash = model.Password };
                ClaimsIdentity claim = await AccountAppUserService.Authenticate(applicationUserDTO);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

#else
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                // usually this will be injected via DI. but creating this manually now for brevity
                IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                var authService = new AdAuthenticationService(authenticationManager);

                var authenticationResult = authService.SignIn(model.Email, model.Password);
                if (authenticationResult.IsSuccess)
                {
                    //if (User.IsInRole("Admin"))
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}
                    //else if (User.IsInRole("User"))
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}

                    // we are in!
                    if (string.IsNullOrWhiteSpace(returnUrl))
                        return RedirectToAction("Index", "Home");

                    return RedirectPermanent(returnUrl);
                }

                ModelState.AddModelError("", authenticationResult.ErrorMessage);
                return View(model);

                //ApplicationUserDTO applicationUserDTO = new ApplicationUserDTO { Email = model.Email, PasswordHash = model.Password };

                //ClaimsIdentity claim = await ApplicationUserService.Authenticate(applicationUserDTO);
                //if (claim == null)
                //{
                //    ModelState.AddModelError("", "Неверный логин или пароль.");
                //}
                //else
                //{
                //    AuthenticationManager.SignOut();
                //    AuthenticationManager.SignIn(new AuthenticationProperties
                //    {
                //        IsPersistent = true
                //    }, claim);
                //    return RedirectToAction("Index", "Home");
                //}
            }
            return View(model);
        }


#endif
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                AppUserRoleDTO AppUserRoleDTO = AccountAppUserService.GetAppUserRoleAssignmentData(1);

                ApplicationUserDTO applicationUserDTO = new ApplicationUserDTO
                {
                    Email = model.Email,
                    PasswordHash = model.Password,
                    //Address = model.Address,
                    UserName = model.Email,
                    Roles = { AppUserRoleDTO }
                };

                OperationDetails operationDetails = await AccountAppUserService.CreateAsync(applicationUserDTO);

                if (operationDetails.Succeeded)
                {
                    //    string code = await ApplicationUserService.GenerateEmailConfirmationTokenAsync(applicationUserDTO.id.ToString());
                    //    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    //    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { UserID = applicationUserDTO.id, code = code }, protocol: Request.Url.Scheme);
                    //    await ApplicationUserService.SendEmailAsync(applicationUserDTO.id.ToString(), "Подтвердите свой аккаунт", "Подтвердите свой аккаунт, нажав <a href=\"" +
                    //callbackUrl + "\">сюда</a>");

                    //    return RedirectToAction("Index", "Home");
                    //return View("SuccessRegister");

                    ClaimsIdentity claim = await AccountAppUserService.Authenticate(applicationUserDTO);
                    if (claim == null)
                    {
                        ModelState.AddModelError("", "Ошибка авторизации");
                    }
                    else
                    {
                        AuthenticationManager.SignOut();
                        AuthenticationManager.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = true
                        }, claim);
                        return RedirectToAction("Index", "Home");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }


        private async Task SetInitialDataAsync()
        {
            AppUserRoleDTO AppUserRoleDTO = AccountAppUserService.GetAppUserRoleAssignmentData(1);

            await AccountAppUserService.SetInitialData(new ApplicationUserDTO
            {
                Email = "asu_dinamika@dinamika-avia.ru",
                UserName = "asu_dinamika@dinamika-avia.ru",
                PasswordHash = "systempass",
                Roles = { { AppUserRoleDTO } }
            }, new List<string> { "User", "Admin" });
        }


        /////////////////////////////////////////////////////////////////



        ////
        //// GET: /Account/Login
        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    string user = Request.ServerVariables["LOGON_USER"];
        //    LoginViewModel model = new LoginViewModel { Email = user };
        //    return View(model);
        //}


        //public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        //{
        //    ManageMessageId? message = null;
        //    IdentityResult result = await UserManager.RemoveLoginAsync(
        //        User.Identity.GetUserId<int>(),
        //        new UserLoginInfo(loginProvider, providerKey));
        //    if (result.Succeeded)
        //    {
        //        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
        //        await SignInAsync(user, isPersistent: false);
        //        message = ManageMessageId.RemoveLoginSuccess;
        //    }
        //    else
        //    {
        //        message = ManageMessageId.Error;
        //    }
        //    return RedirectToAction("Manage", new { Message = message });
        //}

        ////
        //// GET: /Account/ConfirmEmail
        //[AllowAnonymous]
        //public async Task<ActionResult> ConfirmEmail(int userId, string code) 
        //{
        //    if (userId == default(int) || code == null)  
        //    {
        //        return View("Error");
        //    }
        //    var result = await ApplicationUserService.ConfirmEmailAsync(UserId, code);
        //    return View(result.Succeeded ? "Confirm Email" : "Error");
        //}

        ////
        //// GET: /Account/ForgotPassword
        //[AllowAnonymous]
        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //// POST: /Account/ForgotPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await ApplicationUserService.FindByNameAsync(model.Email);
        //        if (user == null || !(await ApplicationUserService.IsEmailConfirmedAsync(user.id)))
        //        {
        //            // Don't reveal that the user does not exist or is not confirmed
        //            return View("ForgotPasswordConfirmation");
        //        }

        //        // For more information on how to enable account confirmation and password reset please visit 
        //        //http://go.microsoft.com/fwlink/?LinkID=320771
        //             // Send an email with this link
        //             string code = await ApplicationUserService.GeneratePasswordResetTokenAsync(user.id);
        //       var callbackUrl = Url.Action("ResetPassword", "Account", new { UserId = user.id, code = code }, protocol: Request.Url.Scheme);

        //       await ApplicationUserService.SendEmailAsync(user.id, "Reset Password", "Please reset your password by clicking < a href =\"" + callbackUrl + "\">here</a>");

        //         return RedirectToAction("ForgotPasswordConfirmation", "Account");
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// GET: /Account/ForgotPasswordConfirmation
        //[AllowAnonymous]
        //public ActionResult ForgotPasswordConfirmation()
        //{
        //    return View();
        //}

        ////
        //// GET: /Account/ResetPassword
        //[AllowAnonymous]
        //public ActionResult ResetPassword(string code)
        //{
        //    return code == null ? View("Error") : View();
        //}

        ////
        //// POST: /Account/ResetPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var user = await ApplicationUserService.FindByNameAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }
        //    var result = await ApplicationUserService.ResetPasswordAsync(user.id, model.Code, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }
        //   // AddErrors(result);
        //    return View();
        //}

        ////
        //// GET: /Account/ResetPasswordConfirmation
        //[AllowAnonymous]
        //public ActionResult ResetPasswordConfirmation()
        //{
        //    return View();
        //}

        ////
        //// POST: /Account/ExternalLogin
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    // Request a redirect to the external login provider
        //    return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        //}


        ////
        //// POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    return RedirectToAction("Index", "Home");
        //}

        ////
        //// GET: /Account/ExternalLoginFailure
        //[AllowAnonymous]
        //public ActionResult ExternalLoginFailure()
        //{
        //    return View();
        //}



        //#region Helpers
        //// Used for XSRF protection when adding external logins
        //private const string XsrfKey = "XsrfId";


        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //internal class ChallengeResult : HttpUnauthorizedResult
        //{
        //    public ChallengeResult(string provider, string redirectUri)
        //        : this(provider, redirectUri, null)
        //    {
        //    }

        //    public ChallengeResult(string provider, string redirectUri, string UserId)
        //    {
        //        LoginProvider = provider;
        //        RedirectUri = redirectUri;
        //        this.UserId = UserId;
        //    }

        //    public string LoginProvider { get; set; }
        //    public string RedirectUri { get; set; }
        //    public string UserId { get; set; }

        //    public override void ExecuteResult(ControllerContext context)
        //    {
        //        var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
        //        if (UserId != null)
        //        {
        //            properties.Dictionary[XsrfKey] = UserId;
        //        }
        //        context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        //    }
        //}
        //#endregion

    }

    //[Authorize]
    //public class AccountController : Controller
    //{
    //    private ApplicationSignInManager _signInManager;
    //    private ApplicationUserManager _userManager;

    //    public AccountController()
    //    {
    //    }

    //    public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
    //    {
    //        UserManager = userManager;
    //        SignInManager = signInManager;
    //    }

    //    public ApplicationSignInManager SignInManager
    //    {
    //        get
    //        {
    //            return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
    //        }
    //        private set 
    //        { 
    //            _signInManager = value; 
    //        }
    //    }

    //    public ApplicationUserManager UserManager
    //    {
    //        get
    //        {
    //            return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //        }
    //        private set
    //        {
    //            _userManager = value;
    //        }
    //    }

    //    //
    //    // GET: /Account/Login
    //    [AllowAnonymous]
    //    public ActionResult Login(string returnUrl)
    //    {
    //        ViewBag.ReturnUrl = returnUrl;
    //        string user = Request.ServerVariables["LOGON_USER"];
    //        LoginViewModel model = new LoginViewModel { Email = user};
    //        return View(model);
    //    }

    //    //
    //    // POST: /Account/Login
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        // This doesn't count login failures towards account lockout
    //        // To enable password failures to trigger account lockout, change to shouldLockout: true
    //        var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                return RedirectToLocal(returnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.RequiresVerification:
    //                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
    //            case SignInStatus.Failure:
    //            default:
    //                ModelState.AddModelError("", "Invalid login attempt.");
    //                return View(model);
    //        }
    //    }

    //    //
    //    // GET: /Account/VerifyCode
    //    [AllowAnonymous]
    //    public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
    //    {
    //        // Require that the user has already logged in via username/password or external login
    //        if (!await SignInManager.HasBeenVerifiedAsync())
    //        {
    //            return View("Error");
    //        }
    //        return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
    //    }

    //    //
    //    // POST: /Account/VerifyCode
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        // The following code protects for brute force attacks against the two factor codes. 
    //        // If a user enters incorrect codes for a specified amount of time then the user account 
    //        // will be locked out for a specified amount of time. 
    //        // You can configure the account lockout settings in IdentityConfig
    //        var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                return RedirectToLocal(model.ReturnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.Failure:
    //            default:
    //                ModelState.AddModelError("", "Invalid code.");
    //                return View(model);
    //        }
    //    }

    //    //
    //    // GET: /Account/Register
    //    [AllowAnonymous]
    //    public ActionResult Register()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Account/Register
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> Register(RegisterViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    //            var result = await UserManager.CreateAsync(user, model.Password);
    //            if (result.Succeeded)
    //            {
    //                await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

    //                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
    //                // Send an email with this link
    //                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.id);
    //                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { UserID = user.id, code = code }, protocol: Request.Url.Scheme);
    //                // await UserManager.SendEmailAsync(user.id, "Confirm your account", "Please confirm your account by clicking <a href=\"" +
    //callbackUrl + "\">here</a>");

    //                return RedirectToAction("Index", "Home");
    //            }
    //            AddErrors(result);
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }

    //    //
    //    // GET: /Account/ConfirmEmail
    //    [AllowAnonymous]
    //    public async Task<ActionResult> ConfirmEmail(string UserId, string code)
    //    {
    //        if (UserId == null || code == null)
    //        {
    //            return View("Error");
    //        }
    //        var result = await UserManager.ConfirmEmailAsync(UserId, code);
    //        return View(result.Succeeded ? "ConfirmEmail" : "Error");
    //    }

    //    //
    //    // GET: /Account/ForgotPassword
    //    [AllowAnonymous]
    //    public ActionResult ForgotPassword()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Account/ForgotPassword
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = await UserManager.FindByNameAsync(model.Email);
    //            if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.id)))
    //            {
    //                // Don't reveal that the user does not exist or is not confirmed
    //                return View("ForgotPasswordConfirmation");
    //            }

    //            // For more information on how to enable account confirmation and password reset please visit 
    //http://go.microsoft.com/fwlink/?LinkID=320771
    //            // Send an email with this link
    //            // string code = await UserManager.GeneratePasswordResetTokenAsync(user.id);
    //            // var callbackUrl = Url.Action("ResetPassword", "Account", new { UserId = user.id, code = code }, 
    // protocol: Request.Url.Scheme);		
    //            // await UserManager.SendEmailAsync(user.id, "Reset Password", "Please reset your password by clicking 
    //<a href=\"" + callbackUrl + "\">here</a>");
    //            // return RedirectToAction("ForgotPasswordConfirmation", "Account");
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }

    //    //
    //    // GET: /Account/ForgotPasswordConfirmation
    //    [AllowAnonymous]
    //    public ActionResult ForgotPasswordConfirmation()
    //    {
    //        return View();
    //    }

    //    //
    //    // GET: /Account/ResetPassword
    //    [AllowAnonymous]
    //    public ActionResult ResetPassword(string code)
    //    {
    //        return code == null ? View("Error") : View();
    //    }

    //    //
    //    // POST: /Account/ResetPassword
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }
    //        var user = await UserManager.FindByNameAsync(model.Email);
    //        if (user == null)
    //        {
    //            // Don't reveal that the user does not exist
    //            return RedirectToAction("ResetPasswordConfirmation", "Account");
    //        }
    //        var result = await UserManager.ResetPasswordAsync(user.id, model.Code, model.Password);
    //        if (result.Succeeded)
    //        {
    //            return RedirectToAction("ResetPasswordConfirmation", "Account");
    //        }
    //        AddErrors(result);
    //        return View();
    //    }

    //    //
    //    // GET: /Account/ResetPasswordConfirmation
    //    [AllowAnonymous]
    //    public ActionResult ResetPasswordConfirmation()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Account/ExternalLogin
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult ExternalLogin(string provider, string returnUrl)
    //    {
    //        // Request a redirect to the external login provider
    //        return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
    //    }

    //    //
    //    // GET: /Account/SendCode
    //    [AllowAnonymous]
    //    public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
    //    {
    //        var UserId = await SignInManager.GetVerifiedUserIdAsync();
    //         if (userId == default(int))
    //        {
    //            return View("Error");
    //        }
    //        var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(UserId);
    //        var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
    //        return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
    //    }

    //    //
    //    // POST: /Account/SendCode
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> SendCode(SendCodeViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View();
    //        }

    //        // Generate the token and send it
    //        if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
    //        {
    //            return View("Error");
    //        }
    //        return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
    //    }

    //    //
    //    // GET: /Account/ExternalLoginCallback
    //    [AllowAnonymous]
    //    public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
    //    {
    //        var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
    //        if (loginInfo == null)
    //        {
    //            return RedirectToAction("Login");
    //        }

    //        // Sign in the user with this external login provider if the user already has a login
    //        var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                return RedirectToLocal(returnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.RequiresVerification:
    //                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
    //            case SignInStatus.Failure:
    //            default:
    //                // If the user does not have an account, then prompt the user to create an account
    //                ViewBag.ReturnUrl = returnUrl;
    //                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
    //                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
    //        }
    //    }

    //    //
    //    // POST: /Account/ExternalLoginConfirmation
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
    //    {
    //        if (User.Identity.IsAuthenticated)
    //        {
    //            return RedirectToAction("Index", "Manage");
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            // Get the information about the user from the external login provider
    //            var info = await AuthenticationManager.GetExternalLoginInfoAsync();
    //            if (info == null)
    //            {
    //                return View("ExternalLoginFailure");
    //            }
    //            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    //            var result = await UserManager.CreateAsync(user);
    //            if (result.Succeeded)
    //            {
    //                result = await UserManager.AddLoginAsync(user.id, info.Login);
    //                if (result.Succeeded)
    //                {
    //                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //                    return RedirectToLocal(returnUrl);
    //                }
    //            }
    //            AddErrors(result);
    //        }

    //        ViewBag.ReturnUrl = returnUrl;
    //        return View(model);
    //    }

    //    //
    //    // POST: /Account/LogOff
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult LogOff()
    //    {
    //        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
    //        return RedirectToAction("Index", "Home");
    //    }

    //    //
    //    // GET: /Account/ExternalLoginFailure
    //    [AllowAnonymous]
    //    public ActionResult ExternalLoginFailure()
    //    {
    //        return View();
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            if (_userManager != null)
    //            {
    //                _userManager.Dispose();
    //                _userManager = null;
    //            }

    //            if (_signInManager != null)
    //            {
    //                _signInManager.Dispose();
    //                _signInManager = null;
    //            }
    //        }

    //        base.Dispose(disposing);
    //    }

    //    #region Helpers
    //    // Used for XSRF protection when adding external logins
    //    private const string XsrfKey = "XsrfId";

    //    private IAuthenticationManager AuthenticationManager
    //    {
    //        get
    //        {
    //            return HttpContext.GetOwinContext().Authentication;
    //        }
    //    }

    //    private void AddErrors(IdentityResult result)
    //    {
    //        foreach (var error in result.Errors)
    //        {
    //            ModelState.AddModelError("", error);
    //        }
    //    }

    //    private ActionResult RedirectToLocal(string returnUrl)
    //    {
    //        if (Url.IsLocalUrl(returnUrl))
    //        {
    //            return Redirect(returnUrl);
    //        }
    //        return RedirectToAction("Index", "Home");
    //    }

    //    internal class ChallengeResult : HttpUnauthorizedResult
    //    {
    //        public ChallengeResult(string provider, string redirectUri)
    //            : this(provider, redirectUri, null)
    //        {
    //        }

    //        public ChallengeResult(string provider, string redirectUri, string UserId)
    //        {
    //            LoginProvider = provider;
    //            RedirectUri = redirectUri;
    //            this.UserId = UserId;
    //        }

    //        public string LoginProvider { get; set; }
    //        public string RedirectUri { get; set; }
    //        public string UserId { get; set; }

    //        public override void ExecuteResult(ControllerContext context)
    //        {
    //            var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
    //            if (UserId != null)
    //            {
    //                properties.Dictionary[XsrfKey] = UserId;
    //            }
    //            context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
    //        }
    //    }
    //    #endregion
    //}
}