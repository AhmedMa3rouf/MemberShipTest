using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Core;
using DAL.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemberShip.Areas.Admin.Controllers
{
    //[Authorize(Roles = "administrator")]
    [Authorize(Roles = RolesConstants.AdminRole)]
   //[Authorize(Roles = RolesConstants.AdminRole, AuthenticationSchemes = "AdminAuth")]
    public class HomeController : BaseAdminController
    {
        public HomeController(
            IAccountManager accountManager,
            ILogger<BaseAdminController> logger):base(accountManager,logger)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}