using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Pagination;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Dtos;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Pagination;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.Contacts.GetAllContacts
{
    internal sealed class GetAllContactsQueryHandler(
        ITrainingRepository contactRepository,
    //ICacheService cacheService,
        IMapper _mapper) : IRequestHandler<GetAllContactsQuery, Result<PaginatedList<ContactListDto>>>
    {
        public async Task<Result<PaginatedList<ContactListDto>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            // string cacheName = "contacts";

            //List<Contact> contacts;
            //contacts = cacheService.Get<List<Contact>>(cacheName);

            var query = contactRepository.GetAll();

            query = query.AsQueryable();

            var pagination = request.pagination ?? new PageRequest();

            var count = await query.CountAsync();
            var items = await query
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .MultiSort(pagination.sortByMultiName, pagination.sortByMultiOrder)
                .ProjectTo<ContactListDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

            // cacheService.Set(cacheName, contacts);

            return new PaginatedList<ContactListDto>(items, count, pagination.Page, pagination.PageSize);
        }
    }
}
