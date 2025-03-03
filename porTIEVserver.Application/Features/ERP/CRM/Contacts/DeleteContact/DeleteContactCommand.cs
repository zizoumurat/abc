using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.Contacts.DeleteContact
{
    public sealed record DeleteContactCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
