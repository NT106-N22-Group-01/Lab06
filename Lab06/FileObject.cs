namespace Lab06
{
	public class FileObject
	{
		public string Name { get; set; }
		public int Size { get; set; }
		public DateTime DateTime { get; set; }
		public bool IsDirectory { get; set; }
		public string Path { get; set; }
		public FileObject() { }
		public FileObject(string name, int size, DateTime dateTime, bool isDirectory, string path)
		{
			Name = name;
			Size = size;
			DateTime = dateTime;
			IsDirectory = isDirectory;
			Path = path;
		}
	}
}
