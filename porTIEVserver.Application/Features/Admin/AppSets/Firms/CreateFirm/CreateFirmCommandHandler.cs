using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.AppSets.Firms.CreateFirm
{
    internal sealed class CreateFirmCommandHandler(
        IFirmRepository firmRepository,
        //ICacheService cacheService,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<CreateFirmCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateFirmCommand request, CancellationToken cancellationToken)
        {
            //string cacheName = "firms";

            bool IsTaxNumberExists = await firmRepository.AnyAsync(p => p.TaxNumber == request.TaxNumber, cancellationToken);

            if (IsTaxNumberExists)
            {
                return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
            }

            Firm firm = mapper.Map<Firm>(request);

            await firmRepository.AddAsync(firm, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            //cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Firm + " " + Messages.MSG_Create + "";
        }
    }

}
