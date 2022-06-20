namespace Thinscale_API_Framework.Tests;

public static class TestSettings
{
	public static string Email { get; set; }

}
public static class DefaultCommunity
{
	public static Enviroment Enviroment { get; set; }
}
public class Enviroment
{
	public string Url { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public string AuthCode { get; set; }
}
