using AutoMapper;
using Pattern.Exam.Domain;
using Pattern.Exam.Infrastructure;
using Pattern.Exam.Services.Interfaces;

namespace Pattern.Exam.Services.Implementation
{
    internal class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BasketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SaveAsync(Basket basket)
        {
            var dbBasket = _mapper.Map<Infrastructure.Entities.Basket>(basket);
            _ = _unitOfWork.GetGenericRepository<Infrastructure.Entities.Basket>().Update(dbBasket);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Basket> GetAsync(Guid accountId)
        {
            var dbBasket = await _unitOfWork.GetGenericRepository<Infrastructure.Entities.Basket>().GetAsync(accountId);

            return _mapper.Map<Basket>(dbBasket);
        }
    }
}
