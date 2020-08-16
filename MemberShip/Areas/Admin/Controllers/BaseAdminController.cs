using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Core.Interfaces;
using DAL.Models;
using MemberShip.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemberShip.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("admin/[controller]")]
    public class BaseAdminController : HelperController
    {

        public BaseAdminController(
            IAccountManager accountManager,
            ILogger<BaseAdminController> logger) : base (accountManager,logger) { }
    }
}