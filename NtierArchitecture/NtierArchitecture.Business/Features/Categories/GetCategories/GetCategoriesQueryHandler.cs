using MediatR;
using Microsoft.EntityFrameworkCore;
using NtierArchitecture.Business.Features.Categories.GetCategories;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;

internal sealed class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAll().OrderBy(p=> p.Name).ToListAsync(cancellationToken);
    }
}
