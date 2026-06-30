using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.DTOs
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(
          @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&*]).{8,10}$",
          ErrorMessage = "Password must be at range 8 and 10 characters and contain letters, numbers, and special characters."
      )]
        public string Password { get; set; }
    }
}
