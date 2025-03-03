using GenericRepository;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Repositories.Admin.ToolSets;
using TS.Result;

namespace porTIEVserver.Application.Features.Admin.ToolSets.Countries.DeleteCountry
{
    internal sealed class DeleteCountryCommandHandler(
        ICountryRepository CountryRepository,
        ICacheService cacheService,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteCountryCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "countries";

            Country country = await CountryRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (country is null)
            {
                return Result<string>.Failure(Messages.MSG_Country + " " + Messages.MSG_NotExist);
            }

            country.IsDeleted = true;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Country + " " + Messages.MSG_Delete + "";


        }
    }
}
