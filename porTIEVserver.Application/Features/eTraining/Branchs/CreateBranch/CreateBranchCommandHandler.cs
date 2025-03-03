using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Features.eTraining.Branchs.CreateBranch;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eTraining;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Branchs.CreateBranch
{
    internal sealed class CreateBranchCommandHandler(
        IBranchRepository branchRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateBranchCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "branchs";

            bool IsCodeExists = await branchRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Branch + " " + Messages.MSG_Exist);
            }

            Branch branch = mapper.Map<Branch>(request);

            await branchRepository.AddAsync(branch, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Branch + " " + Messages.MSG_Create + "";
        }
    }

}
