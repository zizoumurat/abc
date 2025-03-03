using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Banks.UpdateBank
{
    internal sealed class UpdateBankCommandHandler(
    IBankRepository bankRepository,
    ICacheService cacheService,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<UpdateBankCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "banks";

            Bank Bank = await bankRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (Bank is null)
            {
                return Result<string>.Failure(Messages.MSG_Bank + " " + Messages.MSG_NotExist);
            }

            if (Bank.Code != request.Code)
            {
                bool IsCodeExists = await bankRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, Bank);

            Bank.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Bank + " " + Messages.MSG_Update + "";
        }
    }


}
