using System.Net;
using System.Text.RegularExpressions;

namespace Lab06
{
	public class ConnectionManager
	{
		public event EventHandler<string> LogEvent;

		private readonly List<FileObject> fileList = new List<FileObject>();

		protected virtual void OnLogEvent(string message)
		{
			LogEvent?.Invoke(this, message);
		}

		public async Task<bool> ConnectToFTP(ConnectionSetting setting)
		{
			FtpWebRequest request = CreateFtpRequest(setting.Uri, WebRequestMethods.Ftp.ListDirectoryDetails, setting.User, setting.Password);

			try
			{
				using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
				using (Stream responseStream = response.GetResponseStream())
				using (StreamReader reader = new StreamReader(responseStream))
				{
					string line;
					while ((line = await reader.ReadLineAsync()) != null)
					{
						OnLogEvent(line);

						FileObject fileObject = ParseResponseObjects(line, setting.Uri.AbsoluteUri);
						if (!fileObject.IsDirectory)
						{
							fileList.Add(fileObject);
						}
						else
						{
							await TraverseFolder(setting, fileObject.Name);
						}
					}
				}

				OnLogEvent("Downloading file list...");
				return true;
			}
			catch (WebException ex)
			{
				OnLogEvent(ex.Message);
				return false;
			}
		}

		private async Task TraverseFolder(ConnectionSetting setting, string folderName)
		{
			Uri subFolderUri = new Uri(setting.Uri, folderName);
			FtpWebRequest request = CreateFtpRequest(subFolderUri, WebRequestMethods.Ftp.ListDirectoryDetails, setting.User, setting.Password);

			try
			{
				using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
				using (Stream responseStream = response.GetResponseStream())
				using (StreamReader reader = new StreamReader(responseStream))
				{
					string line;
					while ((line = await reader.ReadLineAsync()) != null)
					{
						OnLogEvent(line);

						FileObject fileObject = ParseResponseObjects(line, subFolderUri.AbsoluteUri);
						if (!fileObject.IsDirectory)
						{
							fileList.Add(fileObject);
						}
						else
						{
							await TraverseFolder(setting, Path.Combine(folderName, fileObject.Name));
						}
					}
				}
			}
			catch (WebException ex)
			{
				OnLogEvent(ex.Message);
			}
		}

		private FtpWebRequest CreateFtpRequest(Uri uri, string method, string user, string password)
		{
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
			request.Method = method;
			request.Credentials = new NetworkCredential(user, password);
			request.KeepAlive = true;
			request.UseBinary = true;
			request.UsePassive = true;
			return request;
		}

		public IEnumerable<FileObject> GetFiles()
		{
			return fileList.Where(file => !file.IsDirectory);
		}

		public IEnumerable<FileObject> GetAllFilesAndFolders()
		{
			return fileList;
		}

		public FileObject ParseResponseObjects(string line, string path)
		{
			string pattern = @"^(?<permissions>[drwx\-]+)\s+\d+\s+\w+\s+\w+\s+\s*(?<size>\d+)\s+(?<date>[A-Za-z]{3}\s+\d{1,2}(?:\s+\d{4})?)\s*(?<time>\d{1,2}:\d{1,2})?\s+(?<name>.+)$";


			Regex regex = new Regex(pattern, RegexOptions.Multiline);

			MatchCollection matches = regex.Matches(line);

			string permissions = matches[0].Groups["permissions"].Value;
			int size = Int32.Parse(matches[0].Groups["size"].Value);
			string date = matches[0].Groups["date"].Value;
			string time = matches[0].Groups["time"].Value;
			string name = matches[0].Groups["name"].Value;
			bool isDirectory = permissions.StartsWith("d");

			string dateTimeString = $"{date} {time}";

			DateTime dateTime;
			if (!DateTime.TryParse(dateTimeString, out dateTime))
			{
				dateTime = DateTime.MinValue;
			}

			return new FileObject(name, size, dateTime, isDirectory, path);
		}
	}
}
