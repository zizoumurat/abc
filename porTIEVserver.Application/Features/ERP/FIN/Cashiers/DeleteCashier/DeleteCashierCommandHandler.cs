using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Repositories.Admin;
using TS.Result;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.ERP.FIN;

namespace porTIEVserver.Application.Features.ERP.FIN.Cashiers.DeleteCashier
{
    internal sealed class DeleteCashierCommandHandler(
        ICashierRepository CashierRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteCashierCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCashierCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cashiers";

            Cashier cashier = await CashierRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (cashier is null)
            {
                return Result<string>.Failure(Messages.MSG_Cashier + " " + Messages.MSG_NotExist);
            }

            cashier.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Cashier + " " + Messages.MSG_Delete + "";


        }
    }
}
