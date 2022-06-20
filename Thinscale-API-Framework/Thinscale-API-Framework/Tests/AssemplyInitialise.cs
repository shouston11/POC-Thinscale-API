using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Thinscale_API_Framework.Tests
{
    [TestClass]
    public class AssemplyInitialise
    {
		[AssemblyInitialize]
		public static void SetupTests(TestContext testContext)
		{
			DefaultCommunity.Enviroment = new Enviroment
			{
				Url = testContext.Properties["Url"].ToString(),
				Username = testContext.Properties["Username"].ToString(),
				Password = testContext.Properties["Password"].ToString(),
				AuthCode = testContext.Properties["AuthCode"].ToString(),
			};
		}
	}
}