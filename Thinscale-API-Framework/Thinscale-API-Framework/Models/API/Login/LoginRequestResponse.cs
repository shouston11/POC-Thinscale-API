using System;

namespace Thinscale_API_Framework.Models.API.Login
{
    public class LoginRequestResponse
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string AuthCode { get; set; }

        public string Token { get; set; }

        public DateTimeOffset TokenExpiry { get; set; }

        public Guid[] RoleIds { get; set; }

        public Guid BrokerId { get; set; }
    }
}
