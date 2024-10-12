namespace Lms.BusinessLogic.Dtos;

public class AddBookDto
{
    public AddBookDto()
    {
        UploadedFileDtos = new HashSet<UploadedFileDto>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int  CategoryId { get; set; }
    public int? AuthorId { get; set; }
    public AddAuthorDto Author { get; set; }
    public ICollection<UploadedFileDto> UploadedFileDtos { get; set; }
}
