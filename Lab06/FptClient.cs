namespace Lab06
{
	public partial class FptClient : Form
	{
		private ConnectionManager _connectionManager;
		private ConnectionSetting _connectionSetting;
		public FptClient()
		{
			InitializeComponent();
		}

		private async void buttonConnect_Click(object sender, EventArgs e)
		{
			Uri uri = ParseUrlForFTP(textBoxURL.Text, textBoxPort.Text);
			_connectionSetting = new ConnectionSetting(uri, Int32.Parse(textBoxPort.Text), textBoxUsername.Text, textBoxPassword.Text);
			_connectionManager = new ConnectionManager();
			_connectionManager.ConnectToFTP(_connectionSetting);

		}

		private Uri ParseUrlForFTP(string url, string port)
		{
			// AppendConsole("Parsing provided url and port...");
			if (url.StartsWith("ftp://"))
			{
				// AppendConsole(url + ":" + port);
				return new Uri(url + ":" + port);
			}
			else
			{
				string formattedUrl = "ftp://" + url;
				// AppendConsole(formattedUrl + ":" + port);
				return new Uri(formattedUrl + ":" + port);
			}
		}
		private void LogEventHandler(object sender, string message)
		{
			Console.WriteLine("[Log] " + message);
		}
	}
}