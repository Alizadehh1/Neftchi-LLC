namespace NeftchiLLC.Application.Dtos
{
	public class DocumentGetByIdDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<DocumentFileGetByIdDto> Files { get; set; }
	}
}
