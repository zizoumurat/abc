using MediatR;
using porTIEVserver.Application.Pagination;
using porTIEVserver.Domain.Dtos;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Pagination;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.Contacts.GetAllContacts
{
    public sealed record GetAllContactsQuery(ContactFilterDto filter, PageRequest pagination) : IRequest<Result<PaginatedList<ContactListDto>>>;
}
