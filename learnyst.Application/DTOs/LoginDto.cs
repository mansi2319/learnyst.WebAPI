using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.DTOs
{
    public class LoginDto
    {
        public required int userId { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }

        public string? mobile_number { get; set; }

        public required string password { get; set; }
    }

    public class ForgotPasswordDto
    {
        public string Email { get; set; }
    }

    public class ResetPasswordDto
    {
        public string Token { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
