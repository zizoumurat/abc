using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.Contacts.CreateContact
{
    internal sealed class CreateContactCommandHandler(
        ITrainingRepository contactRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateContactCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "contacts";

            bool IsCodeExists = await contactRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Contact + " " + Messages.MSG_Exist);
            }

            Contact Contact = mapper.Map<Contact>(request);

            await contactRepository.AddAsync(Contact, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Contact + " " + Messages.MSG_Create + "";
        }
    }

}
