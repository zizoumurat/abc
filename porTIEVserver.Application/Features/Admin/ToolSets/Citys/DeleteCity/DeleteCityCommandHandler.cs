using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Cities.DeleteCity
{
    internal sealed class DeleteCityCommandHandler(
        ICityRepository CityRepository,
        ICacheService cacheService,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteCityCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cities";

            City city = await CityRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (city is null)
            {
                return Result<string>.Failure(Messages.MSG_City + " " + Messages.MSG_NotExist);
            }

            city.IsDeleted = true;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_City + " " + Messages.MSG_Delete + "";


        }
    }
}
