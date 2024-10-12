using Lms.Entity.Commons;

namespace Lms.Entity.Books
{
    public class BookAuthor : BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
