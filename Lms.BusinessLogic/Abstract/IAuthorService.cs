using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.BusinessLogic.Abstract
{
    public interface IAuthorService
    {
        public Task<IDictionary<int, string>> GetAuthorDictionaryAsync();
    }
}
