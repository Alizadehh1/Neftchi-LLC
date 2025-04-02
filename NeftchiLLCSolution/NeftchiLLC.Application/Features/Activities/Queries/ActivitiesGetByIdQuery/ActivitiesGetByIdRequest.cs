using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeftchiLLC.Application.Features.Activities.Queries.ActivitiesGetByIdQuery
{
    public class ActivitiesGetByIdRequest : IRequest<ActivitiesGetByIdDto>
    {
		public int Id { get; set; }
	}
}
