using MediatR;
using NtierArchitecture.Entities.Models;

namespace NtierArchitecture.Business.Features.Categories.GetCategories
{
    public sealed record GetCategoriesQuery(): IRequest<List<Category>>;
}
