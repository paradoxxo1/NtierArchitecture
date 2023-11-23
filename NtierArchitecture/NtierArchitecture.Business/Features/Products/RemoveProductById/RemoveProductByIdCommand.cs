using MediatR;

namespace NtierArchitecture.Business.Features.Products.RemoveProductById
{
    public sealed record RemoveProductByIdCommand(
        Guid Id): IRequest;
}
