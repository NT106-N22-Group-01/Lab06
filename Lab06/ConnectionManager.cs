using System.Net;
using System.Net.FtpClient;

namespace Lab06
{
	public class ConnectionManager
	{
		FtpClient _client;

		public event EventHandler<string> LogEvent;

		private List<FtpListItem> fileList = new List<FtpListItem>();

		protected virtual void OnLogEvent(string message)
		{
			LogEvent?.Invoke(this, message);
		}

		public bool Connect(ConnectionSetting setting)
		{
			_client = new FtpClient();
			_client.Host = setting.Uri.Host;
			_client.Credentials = new NetworkCredential(setting.User, setting.Password);
			_client.DataConnectionType = FtpDataConnectionType.AutoPassive;

			try
			{
				OnLogEvent("Connecting...");
				_client.Connect();
				OnLogEvent("Connected, getting file list...");

				FtpListItem[] items = _client.GetListing();
				RetrieveFiles(setting.Uri.AbsolutePath);

				foreach (FtpListItem item in items)
				{
					OnLogEvent($"Add {item.FullName}");
				}

				return true;
			}
			catch (FtpCommandException ex)
			{
				OnLogEvent(ex.Message);
				return false;
			}
			
		}

		public List<FtpListItem> GetFileList()
		{
			return fileList;
		}

		private void RetrieveFiles(string path)
		{
			FtpListItem[] items = _client.GetListing(path);

			foreach (FtpListItem item in items)
			{
				if (item.Type == FtpFileSystemObjectType.File)
				{
					fileList.Add(item);
				}
				else if (item.Type == FtpFileSystemObjectType.Directory)
				{
					RetrieveFiles(item.FullName);
				}
			}
		}

		public async Task<bool> DownloadFile(FtpListItem file, string localFilePath)
		{
			try
			{
				OnLogEvent($"Downloading file: {localFilePath}");
				string remoteFilePath = file.FullName;

				using (Stream outputStream = File.Create(localFilePath))
				{
					using (Stream inputStream = await Task.Run(() => _client.OpenRead(remoteFilePath)))
					{
						byte[] buffer = new byte[2048000];
						long totalBytes = inputStream.Length;
						long downloadedBytes = 0;
						int bytesRead;

						while ((bytesRead = await inputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
						{
							await outputStream.WriteAsync(buffer, 0, bytesRead);
							downloadedBytes += bytesRead;

							int progress = (int)((double)downloadedBytes / totalBytes * 100);

							string progressBar = GenerateProgressBar(progress, 100, 20);

							OnLogEvent($"Downloading: {progressBar} {progress}%");
						}
					}
				}

				OnLogEvent($"Downloaded file: {localFilePath}");
				return true;
			}
			catch (Exception ex)
			{
				OnLogEvent($"Error downloading file: {ex.Message}");
				return false;
			}
		}

		public string GenerateProgressBar(int progress, int total, int length)
		{
			int filledLength = (int)Math.Round(length * (double)progress / total);
			int remainingLength = length - filledLength;

			string progressBar = "[" + new string('#', filledLength) + new string('-', remainingLength) + "]";
			string percentage = $"{progress}%";

			return progressBar + " " + percentage;
		}
	}
}
