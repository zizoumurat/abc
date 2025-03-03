using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.Products.UpdateProduct
{
    internal sealed class UpdateProductCommandHandler(
    IProductRepository productRepository,
    ICacheService cacheService,
    IUnitOfWorkFirm unitOfWorkFirm,
    IMapper mapper
    ) : IRequestHandler<UpdateProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "products";

            Product product = await productRepository.GetByExpressionWithTrackingAsync(p => p.Ref == request.Ref, cancellationToken);

            if (product is null)
            {
                return Result<string>.Failure(Messages.MSG_Product + " " + Messages.MSG_NotExist);
            }

            if (product.Code != request.Code)
            {
                bool IsCodeExists = await productRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

                if (IsCodeExists)
                {
                    return Result<string>.Failure(Messages.MSG_Code + " " + Messages.MSG_Exist);
                }
            }

            if (product.Name != request.Name)
            {
                bool IsNameExists = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

                if (IsNameExists)
                {
                    return Result<string>.Failure(Messages.MSG_Name + " " + Messages.MSG_Exist);
                }
            }

            mapper.Map(request, product);

            product.LastUpdatedDate = DateTime.UtcNow;

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Product + " " + Messages.MSG_Update + "";
        }
    }


}
