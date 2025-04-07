using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
namespace NeftchiLLC.Application.Services
{
    public class FtpFileService
    {
		private readonly FtpFileServiceOptions options;

		public FtpFileService(IOptions<FtpFileServiceOptions> options)
		{
			this.options = options.Value;
		}


		public string Upload(IFormFile file)
		{
			var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
			var remotePath = $"{options.RemoteDirectory}/{randomFileName}";

			using var stream = file.OpenReadStream();

			return randomFileName;
		}
	}
}
