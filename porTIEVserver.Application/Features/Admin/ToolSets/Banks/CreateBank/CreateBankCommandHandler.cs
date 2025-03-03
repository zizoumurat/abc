using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Banks.CreateBank
{
    internal sealed class CreateBankCommandHandler(
        IBankRepository bankRepository,
        ICacheService cacheService,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<CreateBankCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "banks";

            bool IsBankExists = await bankRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsBankExists)
            {
                return Result<string>.Failure(Messages.MSG_Bank + " " + Messages.MSG_Exist);
            }

            Bank bank = mapper.Map<Bank>(request);

            await bankRepository.AddAsync(bank, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Bank + " " + Messages.MSG_Create + "";
        }
    }

}
