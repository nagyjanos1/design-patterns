using AutoMapper;
using Pattern.Exam.Domain;
using Pattern.Exam.Infrastructure;
using Pattern.Exam.Services.Interfaces;

namespace Pattern.Exam.Services.Implementation
{
    internal class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> GetAsync(Guid productId)
        {
            var dbProduct = await _unitOfWork.GetGenericRepository<Infrastructure.Entities.Product>().GetAsync(productId);
            if (dbProduct == null)
                throw new ArgumentException($"Nem létezik ilyen termék. {nameof(productId)}: {productId}");

            return _mapper.Map<Product>(dbProduct);
        }
    }
}
