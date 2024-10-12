using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Commons;
using Microsoft.EntityFrameworkCore.Update;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class UploadFileRepository : GenericRepository<UploadedFile>, IUploadFileRepository
{
    public UploadFileRepository(LmsContext dbContext) : base(dbContext)
    {
    }
}
