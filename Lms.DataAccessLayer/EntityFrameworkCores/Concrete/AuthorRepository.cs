using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Books;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(LmsContext dbContext) : base(dbContext)
    {
    }
}
