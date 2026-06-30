using OrderManagementSystem.Application.Common;
using OrderManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result> RegisterAsync(RegisterUserDto dto);
        Task<LoginResponseDto?> LoginAsync(LoginUserDto dto);
    }
}
