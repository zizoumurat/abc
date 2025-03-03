using AutoMapper;
using MediatR;
using porTIEVserver.Application.Globals;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Repositories.ERP.STK;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.CreateProductStkUnit
{
    internal sealed class CreateProductStkUnitCommandHandler(
        IProductStkUnitRepository ProductStkUnitRepository,
        ICacheService cacheService,
        IUnitOfWorkFirm unitOfWorkFirm,
        IMapper mapper
        ) : IRequestHandler<CreateProductStkUnitCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateProductStkUnitCommand request, CancellationToken cancellationToken)
        {
            string cacheName = "productstkunits";

            bool IsCodeExists = await ProductStkUnitRepository.AnyAsync(p => p.ProductRef == request.ProductRef && p.StkUnitRef == request.StkUnitRef, cancellationToken);

            if (IsCodeExists)
            {
                return Result<string>.Failure(Messages.MSG_ProductStkUnit + " " + Messages.MSG_Exist);
            }

            ProductStkUnit productstkunit = mapper.Map<ProductStkUnit>(request);

            await ProductStkUnitRepository.AddAsync(productstkunit, cancellationToken);

            await unitOfWorkFirm.SaveChangesAsync(cancellationToken);

            cacheService.Remove(cacheName);

            return Messages.MSG_SUCCESSFUL + " : " + Messages.MSG_ProductStkUnit + " " + Messages.MSG_Create + "";
        }
    }

}
