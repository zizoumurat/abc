using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Countries.CreateCountry
{
    internal sealed class CreateCountryCommandHandler(
        ICountryRepository countryRepository,
        ICacheService cacheService,
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<CreateCountryCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "countries";

            bool IsCountryExists = await countryRepository.AnyAsync(p => p.Code3 == request.Code, cancellationToken);

            if (IsCountryExists)
            {
                return Result<string>.Failure(Messages.MSG_Country + " " + Messages.MSG_Exist);
            }

            Country Country = mapper.Map<Country>(request);

            await countryRepository.AddAsync(Country, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Country + " " + Messages.MSG_Create + "";
        }
    }

}
