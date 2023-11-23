using MediatR;

namespace NtierArchitecture.Business.Features.Categories.UpdateCategory
{
    public sealed record UpdateCategoryCommand(
        Guid id,
        string Name): IRequest;
}
