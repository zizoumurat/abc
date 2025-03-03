using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Tradings.DeleteTrading
{
    internal sealed class DeleteTradingCommandHandler(
        ITradingRepository tradingRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteTradingCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteTradingCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "tradings";

            Trading trading = await tradingRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (trading is null)
            {
                return Result<string>.Failure(Messages.MSG_Trading + " " + Messages.MSG_NotExist);
            }

            trading.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Trading + " " + Messages.MSG_Delete + "";


        }
    }
}
