using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Accounts;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;
public class UserDetailRepository : GenericRepository<UserDetail>, IUserDetailRepository
{
    public UserDetailRepository(LmsContext dbContext) : base(dbContext)
    {
    }
}
