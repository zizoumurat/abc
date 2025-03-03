using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.Products.DeleteProduct
{
    internal sealed class DeleteProductCommandHandler(
        IProductRepository ProductRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm
        ) : IRequestHandler<DeleteProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "products";

            Product product = await ProductRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (product is null)
            {
                return Result<string>.Failure(Messages.MSG_Product + " " + Messages.MSG_NotExist);
            }

            product.IsDeleted = true;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Product + " " + Messages.MSG_Delete + "";


        }
    }
}
