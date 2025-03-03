using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Cities.CreateCity
{
    internal sealed class CreateCityCommandHandler(
        ICityRepository cityRepository,
        ICacheService cacheService,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<CreateCityCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "cities";

            bool IsCityExists = await cityRepository.AnyAsync(p => p.Code3 == request.Code, cancellationToken);

            if (IsCityExists)
            {
                return Result<string>.Failure(Messages.MSG_City + " " + Messages.MSG_Exist);
            }

            City city = mapper.Map<City>(request);

            await cityRepository.AddAsync(city, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_City + " " + Messages.MSG_Create + "";
        }
    }

}
