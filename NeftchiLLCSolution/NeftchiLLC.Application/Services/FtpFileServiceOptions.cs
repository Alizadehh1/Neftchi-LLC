namespace NeftchiLLC.Application.Services
{
    public class FtpFileServiceOptions
    {
		public string Host { get; set; }
		public int Port { get; set; } = 21;
		public string UserName { get; set; }
		public string Password { get; set; }
		public string RemoteDirectory { get; set; }
	}
}
