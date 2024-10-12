using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Accounts;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(LmsContext dbContext) : base(dbContext)
    {
    }
}
