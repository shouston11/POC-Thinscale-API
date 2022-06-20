using Thinscale_API_Framework.Models.API.Login;

namespace Thinscale_API_Framework.Tools
{
    public class TestDatGenerator
    {
		public static LoginRequestResponse CreateLoginRequest(string username = null, string password = null, string authCode = null)
		{
			return new LoginRequestResponse
			{
				Username = username,
				Password = password,
				AuthCode = authCode
			};
		}
	}
}
