using MediatR;
using NtierArchitecture.Business.Features.Products.RemoveProductById;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;

internal sealed class RemoveProductByIdCommandHandler : IRequestHandler<RemoveProductByIdCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveProductByIdCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveProductByIdCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(p=> p.Id == request.Id, cancellationToken);
        if (product is null) 
        {
            throw new ArgumentException("ürün bulunamadı");
        }
        _productRepository.Remove(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);        
    }
}
