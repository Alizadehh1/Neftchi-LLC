using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeftchiLLC.Application.Features.Partner.Queries.PartnerGetByIdQuery
{
    public class PartnerGetByIdDto
    {
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? WebsiteUrl { get; set; }
		public string LogoUrl { get; set; }
		public int Order { get; set; }
	}
}
