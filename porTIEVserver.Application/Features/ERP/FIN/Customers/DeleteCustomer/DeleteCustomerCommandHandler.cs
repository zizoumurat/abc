using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Repositories.Admin;
using TS.Result;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.ERP.FIN;

namespace porTIEVserver.Application.Features.ERP.FIN.Customers.DeleteCustomer
{
    internal sealed class DeleteCustomerCommandHandler(
        ICustomerRepository CustomerRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteCustomerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "customers";

            Customer customer = await CustomerRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (customer is null)
            {
                return Result<string>.Failure(Messages.MSG_Customer + " " + Messages.MSG_NotExist);
            }

            customer.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Customer + " " + Messages.MSG_Delete + "";


        }
    }
}
