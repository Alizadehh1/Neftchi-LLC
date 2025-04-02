using FluentFTP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;
namespace NeftchiLLC.Application.Services
{
    public class FtpFileService
    {
		private readonly FtpFileServiceOptions options;

		public FtpFileService(IOptions<FtpFileServiceOptions> options)
		{
			this.options = options.Value;
		}

		private FtpClient CreateClient()
		{
			var client = new FtpClient(options.Host, options.Port)
			{
				Credentials = new NetworkCredential(options.UserName, options.Password)
			};
			client.Connect();
			return client;
		}

		public string Upload(IFormFile file)
		{
			using var client = CreateClient();
			var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
			var remotePath = $"{options.RemoteDirectory}/{randomFileName}";

			using var stream = file.OpenReadStream();
			client.UploadStream(stream, remotePath, FtpRemoteExists.Overwrite);

			return randomFileName;
		}
	}
}
