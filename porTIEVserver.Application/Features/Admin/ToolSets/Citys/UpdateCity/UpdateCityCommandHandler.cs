using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Cities.UpdateCity
{
    internal sealed class UpdateCityCommandHandler(
    ICityRepository cityRepository,
    ICacheService cacheService,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<UpdateCityCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cities";

            City city = await cityRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (city is null)
            {
                return Result<string>.Failure(Messages.MSG_City + " " + Messages.MSG_NotExist);
            }

            if (city.Code3 != request.Code)
            {
                bool IsTaxNumberExists = await cityRepository.AnyAsync(p => p.Code3 == request.Code, cancellationToken);

                if (IsTaxNumberExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, city);

            city.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_City + " " + Messages.MSG_Update + "";
        }
    }


}
