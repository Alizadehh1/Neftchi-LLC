using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeftchiLLC.Application.Features.Activities.Queries.ActivitiesGetByIdQuery
{
    public class ActivitiesGetByIdDto
    {
		public int Id { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
	}
}
