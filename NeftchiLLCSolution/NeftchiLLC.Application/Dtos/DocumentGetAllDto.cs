﻿namespace NeftchiLLC.Application.Dtos
{
	public class DocumentGetAllDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<DocumentFileGetAllDto> Files { get; set; }
	}
}
