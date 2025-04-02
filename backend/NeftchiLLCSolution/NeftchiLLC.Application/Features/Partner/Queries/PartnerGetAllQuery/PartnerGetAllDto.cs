namespace NeftchiLLC.Application.Features.Partner.Queries.PartnerGetAllQuery
{
    public class PartnerGetAllDto
    {
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? WebsiteUrl { get; set; }
		public string LogoUrl { get; set; }
		public int Order { get; set; }
	}
}
