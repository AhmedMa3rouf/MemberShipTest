// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core.Interfaces
{
    public interface IAccountManager
    {

        /*Ma3rouf*/
        Task<ApplicationUser> GetUserAsync(ClaimsPrincipal principal);
        Task<bool> CanSignInAsync(ApplicationUser User);
        Task SignInAsync(ApplicationUser user, bool isPersistent = false, string authenticationMethod = null);

        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent = false, bool lockoutOnFailure = false);

        Task<SignInResult> PasswordSignInAsync(ApplicationUser User, string password, bool isPersistent = false, bool lockoutOnFailure = false);

        Task SignOutAsync();
        /*End Ma3rouf*/
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<(bool Succeeded, string[] Errors)> CreateRoleAsync(ApplicationRole role, IEnumerable<string> claims);
        Task<(bool Succeeded, string[] Errors)> CreateUserAsync(ApplicationUser user, IEnumerable<string> roles, string password);
        Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(ApplicationRole role);
        Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(string roleName);
        Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(ApplicationUser user);
        Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(string userId);
        Task<ApplicationRole> GetRoleByIdAsync(string roleId);
        Task<ApplicationRole> GetRoleByNameAsync(string roleName);
        Task<ApplicationRole> GetRoleLoadRelatedAsync(string roleName);
        Task<List<ApplicationRole>> GetRolesLoadRelatedAsync(int page, int pageSize);
        Task<(ApplicationUser User, string[] Roles)?> GetUserAndRolesAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByUserNameAsync(string userName);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
        Task<List<(ApplicationUser User, string[] Roles)>> GetUsersAndRolesAsync(int page, int pageSize);
        Task<(bool Succeeded, string[] Errors)> ResetPasswordAsync(ApplicationUser user, string newPassword);
        Task<bool> TestCanDeleteRoleAsync(string roleId);
        Task<bool> TestCanDeleteUserAsync(string userId);
        Task<(bool Succeeded, string[] Errors)> UpdatePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
        Task<(bool Succeeded, string[] Errors)> UpdateRoleAsync(ApplicationRole role, IEnumerable<string> claims);
        Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(ApplicationUser user);
        Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(ApplicationUser user, IEnumerable<string> roles);
    }
}
