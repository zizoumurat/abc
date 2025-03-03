using MediatR;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.CreateProductStkUnit;
using porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.DeleteProductStkUnit;
using porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.GetAllProductStkUnits;
using porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.UpdateProductStkUnit;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.ERP.STK
{
    public sealed class ProductStkUnitController : ApiController
    {
        public ProductStkUnitController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllProductStkUnitsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductStkUnitCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductStkUnitCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProductStkUnitCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }

}
