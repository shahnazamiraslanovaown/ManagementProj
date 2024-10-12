using Lms.BusinessLogic.Abstract;
using Lms.DataAccessLayer.Abstract;

namespace Lms.BusinessLogic.Concrete;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IDictionary<int, string>> GetAuthorDictionaryAsync()
    {
        return await _authorRepository.GetDictionaryAsync(x => x.Id, x => x.FullName);
    }
}
