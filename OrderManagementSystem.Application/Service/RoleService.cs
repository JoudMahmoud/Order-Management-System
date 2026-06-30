using Microsoft.AspNetCore.Identity;
using OrderManagementSystem.Application.Interfaces;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Service
{
    public class RoleService:IRoleService
    {
        #region Fields 
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructor
        public RoleService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        #endregion

        #region CRUD Operation
        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            if(!await _userManager.IsInRoleAsync(user, roleName)) 
                await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveUserFromRoleAsync(User user, string roleName)
        {
            if(!await _userManager.IsInRoleAsync(user, roleName))
                await _userManager.RemoveFromRoleAsync(user, roleName);
        }
        #endregion
    }
}
