using AutoMapper;
using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Countries.UpdateCountry
{
    internal sealed class UpdateCountryCommandHandler(
    ICountryRepository countryRepository,
    ICacheService cacheService,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<UpdateCountryCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "countries";

            Country country = await countryRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (country is null)
            {
                return Result<string>.Failure(Messages.MSG_Country + " " + Messages.MSG_NotExist);
            }

            if (country.Code3 != request.Code)
            {
                bool IsTaxNumberExists = await countryRepository.AnyAsync(p => p.Code3 == request.Code, cancellationToken);

                if (IsTaxNumberExists)
                {
                    return Result<string>.Failure(Messages.MSG_TaxNumber + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, country);

            country.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Country + " " + Messages.MSG_Update + "";
        }
    }


}
