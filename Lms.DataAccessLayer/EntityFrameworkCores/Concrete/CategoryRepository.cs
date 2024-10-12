using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Books;
using Microsoft.EntityFrameworkCore;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(LmsContext dbContext) : base(dbContext)
    {
    }

    
}
