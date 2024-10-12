using Lms.Entity.Books;

namespace Lms.DataAccessLayer.Abstract;

public interface IBookRepository: IGenericRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksWithDetailsAsync();
}
