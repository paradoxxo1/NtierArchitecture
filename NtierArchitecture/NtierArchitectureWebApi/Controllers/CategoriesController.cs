using MediatR;
using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Features.Categories.CreateCategory;
using NtierArchitecture.Business.Features.Categories.GetCategories;
using NtierArchitecture.Business.Features.Categories.RemoveCategory;
using NtierArchitecture.Business.Features.Categories.UpdateCategory;
using NtierArchitecture.DataAccess.Authorization;
using NtierArchitectureWebApi.Abstractions;

namespace NtierArchitectureWebApi.Controllers
{
    public sealed class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [RoleFilter("Category.Add")]
        public async Task<IActionResult> Add(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        [RoleFilter("Category.Update")]

        public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        [RoleFilter("Category.Remove")]

        public async Task<IActionResult> RemoveById(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }
        [HttpPost]
        [RoleFilter("Category.GetAll")]

        public async Task<IActionResult> GetAll(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

    }
}
