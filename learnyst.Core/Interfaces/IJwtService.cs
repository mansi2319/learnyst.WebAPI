using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Core.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string tokenType = "access");
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashed);
        int? ValidateToken(string token, string expectedType = "access");
    }
}
