using System.Net.FtpClient;

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
			_connectionManager.LogEvent += LogEventHandler;
			var IsConnected = _connectionManager.Connect(_connectionSetting);
			if (IsConnected)
			{
				List<FtpListItem> fileList = _connectionManager.GetFileList();
				foreach (var item in fileList)
				{
					ListViewItem listItem = new ListViewItem(item.Name);
					listItem.SubItems.Add(item.Modified.ToString());
					listItem.SubItems.Add($"{((int)(item.Size / 1024))} KB");
					listItem.Tag = item;
					listViewDownload.Items.Add(listItem);
				}
			}
		}

		private void listViewDownload_DoubleClick(object sender, EventArgs e)
		{
			if (listViewDownload.SelectedItems.Count > 0)
			{
				ListViewItem selectedItem = listViewDownload.SelectedItems[0];

				FtpListItem selectedFile = (FtpListItem)selectedItem.Tag;

				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.FileName = selectedFile.Name;

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string localFilePath = saveFileDialog.FileName;


					_connectionManager.DownloadFile(selectedFile, localFilePath);
				}
			}
		}

		private Uri ParseUrlForFTP(string url, string port)
		{
			LogEventHandler(this, "Parsing provided url and port...");
			if (url.StartsWith("ftp://"))
			{
				return new Uri(url + ":" + port);
			}
			else
			{
				string formattedUrl = "ftp://" + url;
				return new Uri(formattedUrl + ":" + port);
			}
		}
		private void LogEventHandler(object sender, string message)
		{
			richTextBoxLog.Text += ("[Log] " + message + Environment.NewLine);
		}
	}
}