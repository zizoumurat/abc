using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.DeleteProductStkUnit
{
    internal sealed class DeleteProductStkUnitCommandHandler(
        IProductStkUnitRepository ProductStkUnitRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteProductStkUnitCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductStkUnitCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "productstkunits";

            ProductStkUnit productstkunit = await ProductStkUnitRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (productstkunit is null)
            {
                return Result<string>.Failure(Messages.MSG_ProductStkUnit + " " + Messages.MSG_NotExist);
            }

            productstkunit.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_ProductStkUnit + " " + Messages.MSG_Delete + " ";


        }
    }
}
