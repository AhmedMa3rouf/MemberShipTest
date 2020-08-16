using AutoMapper;
using DAL.Core;
using DAL.Core.Interfaces;
using DAL.Models;
using MemberShip.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberShip.Services
{
    public abstract class HelperController : Controller
    {
        #region Private Fields
        private readonly IAccountManager _accountManager;
        private readonly ILogger<HelperController> _logger;
        #endregion
        
        public HelperController(
            IAccountManager accountManager, 
            ILogger<HelperController> logger)
        {
            _accountManager = accountManager;
            _logger = logger;
        }

        public async Task<IActionResult> UserLoginAsync(LoginVM model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = await _accountManager.GetUserByEmailAsync(model.UserEmail);
                if (user == null)
                {
                    AddError("This User doesn't exists, please check");
                    return View(model);
                }

                //var password = await _accountManager.CheckPasswordAsync(user, model.Password);
                //await _accountManager.CanSignInAsync(user);
                var result = await _accountManager.PasswordSignInAsync(user.UserName,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    //var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToArray();
                    //var roles = await UserManager.GetRolesAsync(user);
                    //var xx = _accountManager.GetUserByEmailAsync(model.UserEmail);
                    var xxxx = await _accountManager.GetUserRolesAsync(_accountManager.GetUserByUserNameAsync(model.UserEmail).Result);
                    //var test = await _accountManager.GetUserAndRolesAsync(_accountManager.GetUserByEmailAsync(model.UserEmail).Id);
                    //HttpContext.User.IsInRole(RolesConstants.AdminRole)
                    bool isdmin = HttpContext?.User.IsInRole(RolesConstants.AdminRole) ?? false;
                    //var isuser = HttpContext?.User.IsInRole("user");
                    //httpAccessor.HttpContext?.User.FindFirst(ClaimConstants.Subject)?.Value?.Trim();
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                        //return RedirectToPage("/Companies", new { area = "MyArea" });
                    }
                    //if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    //{
                    //    return Redirect(model.ReturnUrl);
                    //}
                    else
                    {
                        return isdmin ? RedirectToAction("Index", "Home", new { area = "Admin" }) : RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    if (result.IsLockedOut)
                        AddError("", "You are Locked Out");
                    if (result.IsNotAllowed)
                        AddError("", "You are Note Allowed");
                    else
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            AddError(ModelState.GetModelErrors(), "Invalid login attempt");
            return View(model);
        }

        #region HelperMethod
        public void AddError(IEnumerable<string> errors, string key = "")
        {
            foreach (var error in errors)
            {
                AddError(error, key);
            }
        }

        public void AddError(string error, string key = "")
        {
            ModelState.TryAddModelError(key, error);
            //ModelState.AddModelError(key, error);
        }
        #endregion
    }
}
