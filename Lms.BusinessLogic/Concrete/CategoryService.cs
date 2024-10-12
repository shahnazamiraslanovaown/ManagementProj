using Lms.BusinessLogic.Abstract;
using Lms.DataAccessLayer.Abstract;

namespace Lms.BusinessLogic.Concrete;

public class CategoryService : ICategoryService
{
    //** Dependency Injection - design patterndir.
    //** 1. Asilliqlar kenardan verilir
    //** 2. Sinifler arasinda elaqeni azaldir
    //NUMUNE - CategoryService cts = new CategoryService(new CategoryRepository);
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<IDictionary<int, string>> GetCategoriesDictionaryAsync()
    {
        return await _categoryRepository.GetDictionaryAsync(x=>x.Id,x=>x.Value);
    }
}
