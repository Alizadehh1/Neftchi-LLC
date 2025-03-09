﻿using MediatR;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.StableModels;

namespace NeftchiLLC.Application.Features.License.Queries.LicensesGetAllRequest
{
	class LicensesGetAllRequestHandler(IDocumentRepository documentRepository) : IRequestHandler<LicensesGetAllRequest, IEnumerable<LicensesGetAllDto>>
	{
		public async Task<IEnumerable<LicensesGetAllDto>> Handle(LicensesGetAllRequest request, CancellationToken cancellationToken)
		{
			var documents = documentRepository.GetAll(d => d.DeletedAt == null && d.Type == DocumentType.License);
			var files = documentRepository.GetFiles(d => d.DeletedAt == null && d.IsMain);

			var query = from d in documents
						join f in files on d.Id equals f.DocumentId
						select new LicensesGetAllDto
						{
							Id = d.Id,
							Name = d.Name,
							File = new DocumentGetDto
							{
								Id = f.Id,
								Name = f.Name,
								Path = f.Path,
							},
						};

			return query;
		}
	}
}
