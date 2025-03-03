using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Banks.DeleteBank
{
    internal sealed class DeleteBankCommandHandler(
        IBankRepository bankRepository,
        ICacheService cacheService,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteBankCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "banks";

            Bank bank = await bankRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (bank is null)
            {
                return Result<string>.Failure(Messages.MSG_Bank + " " + Messages.MSG_NotExist);
            }

            bank.IsDeleted = true;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Bank + " " + Messages.MSG_Delete + "";


        }
    }
}
