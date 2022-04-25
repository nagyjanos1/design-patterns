using AutoMapper;
using Pattern.Exam.Domain;
using Pattern.Exam.Infrastructure;
using Pattern.Exam.Services.Interfaces;

namespace Pattern.Exam.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Account> GetAsync(Guid accountId)
        {
            var dbAccount = await _unitOfWork.GetGenericRepository<Infrastructure.Entities.Account>().GetAsync(accountId);
            var account = _mapper.Map<Account>(dbAccount);

            return account;
        }
    }
}
