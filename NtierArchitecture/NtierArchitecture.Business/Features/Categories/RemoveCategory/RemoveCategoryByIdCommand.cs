using MediatR;

namespace NtierArchitecture.Business.Features.Categories.RemoveCategory
{
    public sealed record RemoveCategoryByIdCommand(
        Guid Id) : IRequest;
}
