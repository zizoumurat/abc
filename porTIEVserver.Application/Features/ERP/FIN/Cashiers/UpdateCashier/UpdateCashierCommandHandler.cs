using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Cashiers.UpdateCashier
{
    internal sealed class UpdateCashierCommandHandler(
        ICashierRepository cashierRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateCashierCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCashierCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cashiers";

            Cashier cashier = await cashierRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (cashier is null)
            {
                return Result<string>.Failure(Messages.MSG_Cashier + " " + Messages.MSG_NotExist);
            }

            if (cashier.Code != request.Code)
            {
                bool IsCodeExists = await cashierRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, cashier);

            cashier.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Cashier + " " + Messages.MSG_Update + "";
        }
    }


}
