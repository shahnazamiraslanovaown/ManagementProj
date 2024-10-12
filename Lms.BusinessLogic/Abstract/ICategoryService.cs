namespace Lms.BusinessLogic.Abstract;

public interface ICategoryService
{
    public Task<IDictionary<int, string>> GetCategoriesDictionaryAsync();
}
