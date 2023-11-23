using AutoMapper;
using MediatR;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;

namespace NtierArchitecture.Business.Features.Products.CreateProduct
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            bool isProductNameExists = await _productRepository.AnyAsync(p=> p.Name ==request.Name, cancellationToken);
            if (isProductNameExists)
            {
                throw new ArgumentException("Bu ürün adı daha önce kullanılmış");
            }

            Product product = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
