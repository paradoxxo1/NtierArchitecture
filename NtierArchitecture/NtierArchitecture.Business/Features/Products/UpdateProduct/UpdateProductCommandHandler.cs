using AutoMapper;
using MediatR;
using NtierArchitecture.Business.Features.Products.UpdateProduct;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper; 
    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);
        if (product is null)
        {
            throw new ArgumentNullException("Ürün bulunamadı");
        }
        if (product.Name != request.Name) 
        {
            bool isProductNameExists = await _productRepository.AnyAsync (p=> p.Name == request.Name, cancellationToken);
            if (isProductNameExists)
            {
                throw new ArgumentException("Bu ürün adı daha önce kullanılmış");
            }
        }

        _mapper.Map(request, product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
