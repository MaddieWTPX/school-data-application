using SchoolDataApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class BaseService
    {
        protected readonly SchoolDataApplicationDbContext _schoolDataApplicationDbContext;

        public BaseService(SchoolDataApplicationDbContext schoolDataApplicationDbContext)
        {
            _schoolDataApplicationDbContext = schoolDataApplicationDbContext;
        }
    }
}
