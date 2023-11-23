using MediatR;
using NtierArchitecture.Business.Features.Categories.RemoveCategory;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;

internal sealed class RemoveCategoryByIdCommandHandler : IRequestHandler<RemoveCategoryByIdCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RemoveCategoryByIdCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetByIdAsync(p=> p.Id == request.Id, cancellationToken);
        if (category is null)
        {
            throw new ArgumentException("Kategori Bulunamadı");
        }
        _categoryRepository.Remove(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
