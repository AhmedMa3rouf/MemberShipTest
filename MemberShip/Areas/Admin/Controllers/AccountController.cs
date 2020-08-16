using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Core.Interfaces;
using MemberShip.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemberShip.Areas.Admin.Controllers
{
    public class AccountController : BaseAdminController
    {
        public AccountController(
            IAccountManager accountManager,
            ILogger<BaseAdminController> logger) : base(accountManager, logger)
        {

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginVM { ReturnUrl = returnUrl };
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null)
        {

            return await UserLoginAsync(model, returnUrl);
            returnUrl = returnUrl ?? Url.Content("~/");
            //if (ModelState.IsValid)
            //{
            //    var result = await _signInManager.PasswordSignInAsync(model.UserEmail,
            //       model.Password, model.RememberMe, false);

            //    if (result.Succeeded)
            //    {
            //        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            //        {
            //            return Redirect(returnUrl);
            //        }
            //        //if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            //        //{
            //        //    return Redirect(model.ReturnUrl);
            //        //}
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //}
            //AddError("", "Invalid login attempt");
            //return View(model);
        }
    }
}