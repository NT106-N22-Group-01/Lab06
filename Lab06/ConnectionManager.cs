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

		public async Task<bool> Connect(ConnectionSetting setting)
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

		public void Disconnect()
		{
			_client.Disconnect();
			_client.Dispose();
		}

		public async Task<List<FtpListItem>> GetFileList()
		{
			await RetrieveFiles("/");
			return fileList;
		}

		private async Task RetrieveFiles(string path)
		{
			fileList.Clear();

			FtpListItem[] items = _client.GetListing(path);

			foreach (FtpListItem item in items)
			{
				if (item.Type == FtpFileSystemObjectType.File)
				{
					fileList.Add(item);
				}
				else if (item.Type == FtpFileSystemObjectType.Directory)
				{
					await RetrieveFiles(item.FullName);
				}
			}
		}

		public async Task<bool> DownloadFile(FtpListItem file, string localFilePath)
		{
			try
			{
				OnLogEvent($"Downloading file: {localFilePath}");
				string remoteFilePath = file.FullName;

				
				long downloadedBytes = 0;
				var progress = new Progress<int>(percentage =>
				{
					string progressBar = GenerateProgressBar(percentage, 100, 20);
					OnLogEvent($"Downloading: {progressBar} {percentage}%");
				});

				using (Stream outputStream = File.Create(localFilePath))
				{
					using (Stream inputStream = await Task.Run(() => _client.OpenRead(remoteFilePath)))
					{
						byte[] buffer = new byte[1024000];
						int bytesRead;
						long totalBytes = inputStream.Length;

						while ((bytesRead = await inputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
						{
							await outputStream.WriteAsync(buffer, 0, bytesRead);
							downloadedBytes += bytesRead;

							int percentage = (int)((double)downloadedBytes / totalBytes * 100);
							((IProgress<int>)progress).Report(percentage);
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

		public async Task<bool> UploadFile(string localFilePath, string remoteFilePath)
		{
			try
			{
				OnLogEvent($"Uploading file: {localFilePath}");

				long totalBytes = new FileInfo(localFilePath).Length;
				long uploadedBytes = 0;

				var progress = new Progress<int>(percentage =>
				{
					string progressBar = GenerateProgressBar(percentage, 100, 20);
					OnLogEvent($"Uploading: {progressBar} {percentage}%");
				});

				using (Stream outputStream = await Task.Run(() => _client.OpenWrite(remoteFilePath)))
				{
					using (Stream inputStream = File.OpenRead(localFilePath))
					{
						byte[] buffer = new byte[1024000];
						int bytesRead;

						while ((bytesRead = await inputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
						{
							await outputStream.WriteAsync(buffer, 0, bytesRead);
							uploadedBytes += bytesRead;

							int percentage = (int)((double)uploadedBytes / totalBytes * 100);
							((IProgress<int>)progress).Report(percentage);
						}
					}
				}


				OnLogEvent($"Uploaded file: {localFilePath}");
				return true;
			}
			catch (Exception ex)
			{
				OnLogEvent($"Error uploading file: {ex.Message}");
				return false;
			}
		}

		public string GenerateProgressBar(int progress, int total, int length)
		{
			int filledLength = (int)Math.Round(length * (double)progress / total);
			int remainingLength = length - filledLength;

			return "[" + new string('#', filledLength) + new string('-', remainingLength) + "]";
		}
	}
}
