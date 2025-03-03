using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.eBizService.eBizService;
using porTIEVserver.Domain.Entities.eCargo;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.eBizService;
using porTIEVserver.Domain.Repositories.eCargo;
using TS.Result;

namespace porTIEVserver.Application.Features.eCargo.BizServices.CreateBizService
{
    internal sealed class CreateBizServiceCommandHandler(
        IBizServiceRepository BizServiceRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateBizServiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateBizServiceCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "bizservices";

            bool IsCodeExists = await BizServiceRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_BizService + " " + Messages.MSG_Exist);
            }

            BizService bizService = mapper.Map<BizService>(request);

            await BizServiceRepository.AddAsync(bizService, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_BizService + " " + Messages.MSG_Create + "";
        }
    }

}
