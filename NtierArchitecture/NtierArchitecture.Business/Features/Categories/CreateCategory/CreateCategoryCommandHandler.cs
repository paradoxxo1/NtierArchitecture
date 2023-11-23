using AutoMapper;
using MediatR;
using NtierArchitecture.Business.Features.Categories.CreateCategory;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;

internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;  //kayıt işlemi yapar
    private readonly IUnitOfWork _unitOfWork;  //Transaction işlemi bitirdikten sonra database gönderilme işlemi yapacak
    private readonly IMapper _mapper;


    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var isCategoryNameExists = await _categoryRepository.AnyAsync( p=> p.Name == request.Name, cancellationToken);

        if (isCategoryNameExists)
        {
            throw new ArgumentException("Bu kategori daha önce oluşturulmuş");
        }

        Category category = _mapper.Map<Category>(request);

        await _categoryRepository.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
