using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Repositories.Admin;
using TS.Result;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.ERP.FIN;

namespace porTIEVserver.Application.Features.ERP.FIN.BankAccounts.DeleteBankAccount
{
    internal sealed class DeleteBankAccountCommandHandler(
        IBankAccountRepository BankAccountRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteBankAccountCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "bankAccounts";

            BankAccount bankAccount = await BankAccountRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (bankAccount is null)
            {
                return Result<string>.Failure(Messages.MSG_BankAccount + " " + Messages.MSG_NotExist);
            }

            bankAccount.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_BankAccount + " " + Messages.MSG_Delete + "";


        }
    }
}
