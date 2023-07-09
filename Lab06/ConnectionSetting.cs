namespace Lab06
{
	public class ConnectionSetting
	{
		public Uri Uri { get; set; }
		public int Port { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
		public ConnectionSetting() { }
		public ConnectionSetting(Uri uRL, int port, string user, string password)
		{
			Uri = uRL;
			Port = port;
			User = user;
			Password = password;
		}
	}
}
