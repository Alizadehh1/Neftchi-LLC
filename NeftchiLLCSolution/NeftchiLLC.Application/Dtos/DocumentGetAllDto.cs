namespace NeftchiLLC.Application.Dtos
{
	public class DocumentGetAllDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DocumentFileGetAllDto File { get; set; }
	}
}
