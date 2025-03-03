using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.Products.CreateProduct
{
    internal sealed class CreateProductCommandHandler(
        IProductRepository ProductRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "products";

            bool IsCodeExists = await ProductRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_Product + " " + Messages.MSG_Exist);
            }

            Product product = mapper.Map<Product>(request);

            await ProductRepository.AddAsync(product, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_Product + " " + Messages.MSG_Create + "";
        }
    }

}
