using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Cashiers.CreateCashier
{
    internal sealed class CreateCashierCommandHandler(
        ICashierRepository CashierRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateCashierCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCashierCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cashiers";

            bool IsCodeExists = await CashierRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Cashier + " " + Messages.MSG_Exist);
            }

            Cashier Cashier = mapper.Map<Cashier>(request);

            await CashierRepository.AddAsync(Cashier, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Cashier + " " + Messages.MSG_Create + "";
        }
    }

}
