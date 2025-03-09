namespace NeftchiLLC.Application.Dtos
{
	public class DocumentGetDto
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Path { get; set; }
	}
}
