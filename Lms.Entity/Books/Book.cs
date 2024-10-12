using Lms.Entity.Commons;

namespace Lms.Entity.Books;

public class Book : EditedBaseEntity
{
    public Book()
    {
        BookAuthors = [];
        UploadedFiles = [];
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<UploadedFile> UploadedFiles { get; set; }


}
