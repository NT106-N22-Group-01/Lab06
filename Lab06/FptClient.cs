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
			var IsConnected = await _connectionManager.Connect(_connectionSetting);
			buttonConnect.Enabled = false;
			if (IsConnected)
			{
				List<FtpListItem> fileList = await _connectionManager.GetFileList();
				UpdateList(fileList);
				buttonBrowse.Enabled = true;
				buttonDisconnect.Enabled = true;
				buttonRefresh.Enabled = true;
			}
			else
			{
				buttonConnect.Enabled = true;
			}
		}

		private void buttonDisconnect_Click(object sender, EventArgs e)
		{
			_connectionManager.Disconnect();
			listViewDownload.Items.Clear();
			buttonConnect.Enabled = true;
			buttonBrowse.Enabled = false;
			buttonRefresh.Enabled = false;
			buttonDisconnect.Enabled = false;
		}

		private async void listViewDownload_DoubleClick(object sender, EventArgs e)
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


					var isDownloaded = await _connectionManager.DownloadFile(selectedFile, localFilePath);
				}
			}
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				richTextBoxUpload.Text = openFileDialog.FileName;
				buttonUpload.Enabled = true;
			}
		}

		private async void buttonUpload_Click(object sender, EventArgs e)
		{
			var isUploaded = await _connectionManager.UploadFile(richTextBoxUpload.Text, $"/{Path.GetFileName(richTextBoxUpload.Text)}");
			if (isUploaded)
			{
				buttonUpload.Enabled = false;
				List<FtpListItem> fileList = await _connectionManager.GetFileList();
				UpdateList(fileList);
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
			richTextBoxLog.AppendText("[Log] " + message + Environment.NewLine);
			richTextBoxLog.ScrollToCaret();
		}

		private void UpdateList(List<FtpListItem> fileList)
		{
			listViewDownload.Items.Clear();
			foreach (var item in fileList)
			{
				ListViewItem listItem = new ListViewItem(item.Name);
				listItem.SubItems.Add(item.Modified.ToString());
				listItem.SubItems.Add($"{((int)(item.Size / 1024))} KB");
				listItem.Tag = item;
				listViewDownload.Items.Add(listItem);
			}
		}

		private async void buttonRefresh_Click(object sender, EventArgs e)
		{
			List<FtpListItem> fileList = await _connectionManager.GetFileList();
			UpdateList(fileList);
		}
	}
}