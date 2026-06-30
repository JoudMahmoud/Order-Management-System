using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using OrderManagementSystem.Application.Common;
using OrderManagementSystem.Application.DTOs;
using OrderManagementSystem.Application.Interfaces;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Service
{
    public class AuthService:IAuthService
    {
        #region Fields 
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        private readonly IConfiguration _config;

       

        #endregion

        #region Constructor
        public AuthService(UserManager<User> userManager, IMapper mapper,IRoleService roleService,IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleService = roleService;
            _config = config;
        }

        #endregion

        #region CRUD Operation
        public async Task<Result> RegisterAsync(RegisterUserDto dto)
        {
            var existedUser = await _userManager.Users.FirstOrDefaultAsync(u=>u.Email== dto.Email);
            if (existedUser != null) 
                return Result.Failure("Email is already in use.");

            var customer = _mapper.Map<Customer>(dto);
            IdentityResult result = await _userManager.CreateAsync(customer,dto.Password);

            if (result.Succeeded)
            {
                await _roleService.AddUserToRoleAsync(customer, "Customer");
                return Result.Success("Customer added successfuly.");
            }
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            return Result.Failure(errors);
        }

        public async Task<LoginResponseDto?>LoginAsync(LoginUserDto dto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u=>u.Email==dto.Email); 
            if(user == null)
                return null;

            var validPassword = await _userManager.CheckPasswordAsync(user, dto.Password);
            if(!validPassword)
                return null;

            return GenerateJwtToken(user);

        }

        private LoginResponseDto GenerateJwtToken(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("userId", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                };
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));

            var signingCredentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(24);
            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials);

            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
        #endregion

    }
}
        //#region Fields 

        //#endregion

        //#region Constructor


        //#endregion

        //#region CRUD Operation
        //#endregion
