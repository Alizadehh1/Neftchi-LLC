using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace NeftchiLLC.Application.Services
{
	public class AzureBlobService
	{
		private readonly BlobContainerClient _container;

		public AzureBlobService(IConfiguration config)
		{
			var connection = config["AzureBlobStorage:ConnectionString"];
			var containerName = config["AzureBlobStorage:ContainerName"];
			_container = new BlobContainerClient(connection, containerName);
			_container.CreateIfNotExists();
		}

		public async Task<string> UploadAsync(IFormFile file)
		{
			var blob = _container.GetBlobClient(file.FileName);
			await using var stream = file.OpenReadStream();
			await blob.UploadAsync(stream, true);
			return blob.Uri.ToString();
		}
		public async Task RemoveAsync(string filePath)
		{
			var blobClient = _container.GetBlobClient(filePath);
			await blobClient.DeleteIfExistsAsync();
		}
	}
}
