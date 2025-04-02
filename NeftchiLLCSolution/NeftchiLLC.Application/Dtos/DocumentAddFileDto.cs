using Microsoft.AspNetCore.Http;

namespace NeftchiLLC.Application.Dtos
{
	public class DocumentAddFileDto
	{
		public int Id { get; set; }
		public required IFormFile File { get; set; }
		public bool IsMain { get; set; }
	}
}
