using AutoMapper;
using Pattern.Exam.Domain;
using Pattern.Exam.Infrastructure;
using Pattern.Exam.Services.Interfaces;

namespace Pattern.Exam.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SaveAsync(Order order)
        {
            var dbOrder = _mapper.Map<Infrastructure.Entities.Order>(order);

            await _unitOfWork.GetGenericRepository<Infrastructure.Entities.Order>().AddAsync(dbOrder);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Order> GetAsync(Guid accountId)
        {
            var dbOrder = await _unitOfWork.GetGenericRepository<Infrastructure.Entities.Order>().GetAsync(accountId);

            return _mapper.Map<Order>(dbOrder);
        }
    }
}
