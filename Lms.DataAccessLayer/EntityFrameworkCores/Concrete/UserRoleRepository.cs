using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Accounts;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(LmsContext dbContext) : base(dbContext)
    {
    }
}
