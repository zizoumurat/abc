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
            if (request.filter != null)
            {
                query = query.Where(x =>
                    (request.filter.ContactType != null || x.ContactType == request.filter.ContactType) &&
                    (string.IsNullOrEmpty(request.filter.FirstName) || x.FirstName.ToLower().Contains(request.filter.FirstName.ToLower())) &&
                    (string.IsNullOrEmpty(request.filter.LastName) || x.LastName.ToLower().Contains(request.filter.LastName.ToLower())) &&
                    (string.IsNullOrEmpty(request.filter.Code) || x.Code.ToLower().Contains(request.filter.Code.ToLower())) &&
                    (string.IsNullOrEmpty(request.filter.CityRef) || x.CityRef.ToLower().Contains(request.filter.CityRef.ToLower())) &&
                    (string.IsNullOrEmpty(request.filter.Phone) || x.Phone.ToLower().Contains(request.filter.Phone.ToLower()))
                );
            }

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

            return new PaginatedList<ContactListDto>(items, count, request.pagination.Page, request.pagination.PageSize);
        }
    }
}
