namespace NeftchiLLC.Application.Dtos
{
	public class DocumentFileGetByIdDto
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Path { get; set; }
		public bool IsMain { get; set; }
	}
}
