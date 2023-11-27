using MediatR;
using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Features.Products.CreateProduct;
using NtierArchitecture.Business.Features.Products.GetProducts;
using NtierArchitecture.Business.Features.Products.RemoveProductById;
using NtierArchitecture.Business.Features.Products.UpdateProduct;
using NtierArchitecture.DataAccess.Authorization;
using NtierArchitectureWebApi.Abstractions;

namespace NtierArchitectureWebApi.Controllers
{
    public sealed class ProductsController : ApiController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        [RoleFilter("Product.Add")]

        public async Task<IActionResult> Add(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        [RoleFilter("Product.Update")]

        public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        [RoleFilter("Product.Remov")]

        public async Task<IActionResult> RemoveById(RemoveProductByIdCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Product.GetAll")]

        public async Task<IActionResult> GetAll(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
