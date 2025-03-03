using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Tradings.CreateTrading
{
    internal sealed class CreateTradingCommandHandler(
        ITradingRepository tradingRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateTradingCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateTradingCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "tradings";

            bool IsCodeExists = await tradingRepository.AnyAsync(p => p.FicheNumber == request.FicheNumber, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Trading + " " + Messages.MSG_Exist);
            }

            Trading trading = mapper.Map<Trading>(request);

            await tradingRepository.AddAsync(trading, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Trading + " " + Messages.MSG_Create + "";
        }
    }

}
