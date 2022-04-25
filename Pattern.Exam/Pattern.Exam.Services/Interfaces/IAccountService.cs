using Pattern.Exam.Domain;

namespace Pattern.Exam.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetAsync(Guid accountId);
    }
}