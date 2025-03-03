using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.BankAccounts.GetAllBankAccounts
{
    internal sealed class GetAllBankAccountsQueryHandler(
        IBankAccountRepository bankAccountRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllBankAccountsQuery, Result<List<BankAccount>>>
    {
        public async Task<Result<List<BankAccount>>> Handle(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "bankAccounts";

            List<BankAccount> bankAccounts = new();
            bankAccounts = cacheService.Get<List<BankAccount>>(cacheName);
            if (bankAccounts is null)
            {
                bankAccounts =
                    await bankAccountRepository
                    .GetAll()
                    //.Where(p => request.BankAccountTypeValue > 0 && p.BankAccountType.Value == request.BankAccountTypeValue)
                    .OrderBy(p => p.BankRef)
                     .ThenBy(p => p.BankBranchRef)
                     .ThenBy(p => p.AccountNumber)
                    .ToListAsync(cancellationToken);

                cacheService.Set(cacheName, bankAccounts);
            }

            return bankAccounts;
        }
    }
}
