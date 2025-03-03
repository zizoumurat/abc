using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.UpdateProductStkUnit
{
    internal sealed class UpdateProductStkUnitCommandHandler(
        IProductStkUnitRepository productstkunitRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<UpdateProductStkUnitCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateProductStkUnitCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "productstkunits";

            ProductStkUnit productstkunit = await productstkunitRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (productstkunit is null)
            {
                return Result<string>.Failure(Messages.MSG_ProductStkUnit + " " + Messages.MSG_NotExist);
            }

            if (productstkunit.ProductRef != request.ProductRef || productstkunit.StkUnitRef != request.StkUnitRef)
            {
                bool IsCodeExists = await productstkunitRepository.AnyAsync(p => p.ProductRef == request.ProductRef && p.StkUnitRef == request.StkUnitRef, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_ProductStkUnit + " " + Messages.MSG_Exist);
                }
            }


            mapper.Map(request, productstkunit);

            productstkunit.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_ProductStkUnit + " " + Messages.MSG_Update + "";
        }
    }


}
