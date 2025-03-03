using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.BankAccounts.CreateBankAccount
{
    internal sealed class CreateBankAccountCommandHandler(
        IBankAccountRepository BankAccountRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateBankAccountCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "bankAccounts";

            bool IsCodeExists = await BankAccountRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_BankAccount + " " + Messages.MSG_Exist);
            }

            BankAccount BankAccount = mapper.Map<BankAccount>(request);

            await BankAccountRepository.AddAsync(BankAccount, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_BankAccount + " " + Messages.MSG_Create + "";
        }
    }

}
