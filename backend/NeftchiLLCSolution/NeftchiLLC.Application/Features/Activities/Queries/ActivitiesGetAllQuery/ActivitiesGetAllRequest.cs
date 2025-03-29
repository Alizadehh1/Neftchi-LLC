using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeftchiLLC.Application.Features.Activities.Queries.ActivitiesGetAllQuery
{
    public class ActivitiesGetAllRequest : IRequest<List<ActivitiesGetAllDto>>
    {
    }
}
