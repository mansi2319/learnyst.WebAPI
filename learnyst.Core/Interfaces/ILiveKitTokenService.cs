using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Core.Interfaces
{
    public interface ILiveKitTokenService
    {
        string GenerateToken(string identity, string roomName);
    }
}
