using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Books;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class BookAuthorRepository : GenericRepository<BookAuthor>, IBookAuthorRepository
{
    public BookAuthorRepository(LmsContext dbContext) : base(dbContext)
    {
    }
}
