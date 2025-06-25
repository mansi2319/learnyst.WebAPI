using learnyst.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Application.Services
{
    public class LiveKitTokenService : ILiveKitTokenService
    {
        private readonly IConfiguration _config;

        public LiveKitTokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string identity, string roomName)
        {
            string apiKey = _config["LiveKit:ApiKey"];
            string apiSecret = _config["LiveKit:ApiSecret"];

            var token = new Livekit.Server.Sdk.Dotnet.AccessToken(apiKey, apiSecret)
                .WithIdentity(identity)
                .WithGrants(new Livekit.Server.Sdk.Dotnet.VideoGrants
                {
                    RoomJoin = true,
                    Room = roomName
                });

            return token.ToJwt();
        }
    }
}
