using MediatR;

namespace NtierArchitecture.Business.Features.Categories.CreateCategory
{
    public sealed record  CreateCategoryCommand (
        string Name): IRequest;
}
