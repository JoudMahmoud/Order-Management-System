using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.DTOs;
using OrderManagementSystem.Application.Interfaces;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Fields 
        private readonly IAuthService _authService;
        #endregion

        #region Constructor
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        #endregion

        #region CRUD Operation
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody]RegisterUserDto dto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new {message = result.Message});

            return Ok(new { message = result.Message });
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginUserDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if(result==null)
                return Unauthorized();
            return Ok(result);
        }
       
        #endregion

    }
}
