using Lms.Entity.Accounts;

namespace Lms.DataAccessLayer.Abstract;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetSigninUserWithDetailAsync(string email);
}
