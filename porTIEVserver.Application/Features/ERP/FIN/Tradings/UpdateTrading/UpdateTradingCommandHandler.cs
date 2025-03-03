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

namespace porTIEVserver.Application.Features.ERP.FIN.Tradings.UpdateTrading
{
    internal sealed class UpdateTradingCommandHandler(
        ITradingRepository tradingRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateTradingCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateTradingCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "tradings";

            Trading trading = await tradingRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (trading is null)
            {
                return Result<string>.Failure(Messages.MSG_Trading + " " + Messages.MSG_NotExist);
            }

            if (trading.FicheNumber != request.FicheNumber)
            {
                bool IsCodeExists = await tradingRepository.AnyAsync(p => p.FicheNumber == request.FicheNumber, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, trading);

            trading.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Trading + " " + Messages.MSG_Update + "";
        }
    }


}
