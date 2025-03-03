using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.Contacts.UpdateContact
{
    internal sealed class UpdateContactCommandHandler(
        ITrainingRepository contactRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateContactCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "contacts";

            Contact contact = await contactRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (contact is null)
            {
                return Result<string>.Failure(Messages.MSG_Contact + " " + Messages.MSG_NotExist);
            }

            if (contact.Code != request.Code)
            {
                bool IsCodeExists = await contactRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, contact);

            contact.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Contact + " " + Messages.MSG_Update + "";
        }
    }


}
