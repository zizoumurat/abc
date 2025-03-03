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

namespace porTIEVserver.Application.Features.ERP.FIN.BankAccounts.UpdateBankAccount
{
    internal sealed class UpdateBankAccountCommandHandler(
        IBankAccountRepository bankAccountRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateBankAccountCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "bankAccounts";

            BankAccount bankAccount = await bankAccountRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (bankAccount is null)
            {
                return Result<string>.Failure(Messages.MSG_BankAccount + " " + Messages.MSG_NotExist);
            }

            if (bankAccount.Code != request.Code)
            {
                bool IsCodeExists = await bankAccountRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, bankAccount);

            bankAccount.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_BankAccount + " " + Messages.MSG_Update + "";
        }
    }


}
