using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Books;
using Microsoft.EntityFrameworkCore;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(LmsContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Book>> GetBooksWithDetailsAsync()
    {
        return await TableEntity
             .Include(x => x.Category)
             .Include(x => x.UploadedFiles)
             .Include(x => x.BookAuthors)
             .ThenInclude(x => x.Author)
             .OrderByDescending(x => x.Id)
             .AsNoTrackingWithIdentityResolution()
             .ToListAsync();
    }
}
