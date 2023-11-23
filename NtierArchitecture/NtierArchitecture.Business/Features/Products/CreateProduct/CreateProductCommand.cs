using MediatR;

namespace NtierArchitecture.Business.Features.Products.CreateProduct
{
    public sealed record CreateProductCommand(
        string Name,
        decimal Price,
        int Quantity,
        Guid CategoryId): IRequest<Unit>;
}
