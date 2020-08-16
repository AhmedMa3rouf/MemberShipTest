using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Core.Interfaces;
using MemberShip.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemberShip.Areas.Admin.Controllers
{
    public class MemberController : BaseAdminController
    {
        IAccountManager _accountManager;
        ILogger<MemberController> _logger;
        private readonly IMapper _mapper;
        public MemberController(
            IAccountManager accountManager,
            ILogger<MemberController> logger,
            IMapper mapper) : base(accountManager, logger)
        {
            _accountManager = accountManager;
            _logger = logger;
            _mapper = mapper;

        }
        public async Task<IActionResult> IndexAsync()
        {
            return await Members();
        }
        //[HttpGet("users/{pageNumber:int}/{pageSize:int}")]
        [HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<UserViewModel>))]
        public async Task<IActionResult> Members()
        {
            var usersAndRoles = await _accountManager.GetUsersAndRolesAsync(1, 20);

            List<UserViewModel> usersVM = new List<UserViewModel>();

            foreach (var item in usersAndRoles)
            {
                var userVM = _mapper.Map<UserViewModel>(item.User);
                /*userVM.Roles = item.Roles*/;

                usersVM.Add(userVM);
            }

            return Ok(usersVM);
        }
    }
}