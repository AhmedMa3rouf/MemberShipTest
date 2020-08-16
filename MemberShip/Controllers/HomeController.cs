using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MemberShip.Models;
using DAL.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using DAL.Models;

namespace MemberShip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountManager _accountManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger, IAccountManager accountManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _accountManager = accountManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        { 
           ApplicationUser user = _userManager.GetUserAsync
                             (HttpContext.User).Result;
            if (HttpContext?.User !=null)
            {
                //var isdmin = HttpContext?.User.IsInRole("administrator");
                //var isuser = HttpContext?.User.IsInRole("user");
                //var isdmin = HttpContext?.User.IsInRole("administrator");
                //var xxxx = await _accountManager.GetUserRolesAsync(user);

                //DAL.Models.ApplicationUser user2 = _accountManager.GetUserAsync
                //             (HttpContext.User).Result;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
