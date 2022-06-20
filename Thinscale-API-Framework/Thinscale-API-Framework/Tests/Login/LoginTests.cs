using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using Thinscale_API_Framework.HttpHelper;
using Thinscale_API_Framework.Models.API.Login;

namespace Thinscale_API_Framework.Tests.Login
{
    [TestClass]
    public class LoginTests
    {
		string Url => DefaultCommunity.Enviroment.Url;
		string Username => DefaultCommunity.Enviroment.Username;
		string Password => DefaultCommunity.Enviroment.Password;
		string AuthCode => DefaultCommunity.Enviroment.AuthCode;

		private string authCode => AuthCode;
		private string postLoginEndpoint => $"{Url}/api/admin/login";
		private string username => Username;
		private string password => Password;
		

		/// <summary>
		/// Thinscale - POST - Login - Happy - Valid Request
		/// Endpoint: POST {base_url}/api/admin/login
		/// </summary>
		/// <returns></returns>
		[TestMethod]
		[TestCategory("Integration")]
		public async Task PostLoginSuccess()
		{
			var impersonateUser = Tools.TestDatGenerator.CreateLoginRequest(username: username, password: password, authCode:authCode);

			var loginUser = await ApiTestbase.MakePostRequestAsync<LoginRequestResponse, LoginRequestResponse>(uri: postLoginEndpoint, resource: impersonateUser, expectedStatusCode: HttpStatusCode.OK, accessToken: authCode).ConfigureAwait(false);

			Assert.IsNotNull(loginUser.Token);
		}
	}
}
