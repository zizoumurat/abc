using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.CRM.Contacts.DeleteContact
{
    internal sealed class DeleteContactCommandHandler(
        ITrainingRepository ContactRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteContactCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "contacts";

            Contact contact = await ContactRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (contact is null)
            {
                return Result<string>.Failure(Messages.MSG_Contact + " " + Messages.MSG_NotExist);
            }

            contact.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Contact + " " + Messages.MSG_Delete + "";


        }
    }
}
