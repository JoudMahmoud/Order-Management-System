using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Interfaces
{
    public interface IRoleService
    {
        Task AddUserToRoleAsync(User user, string roleName);
        Task RemoveUserFromRoleAsync(User user, string roleName);
    }
}
