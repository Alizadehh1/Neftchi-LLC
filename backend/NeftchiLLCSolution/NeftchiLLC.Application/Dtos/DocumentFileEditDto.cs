using Microsoft.AspNetCore.Http;

namespace NeftchiLLC.Application.Dtos
{
	public class DocumentFileEditDto
	{
		public int Id { get; set; }
		public IFormFile? File { get; set; }
		public bool IsMain { get; set; }
	}
}
