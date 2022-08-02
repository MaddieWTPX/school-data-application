using SchoolDataApplication.Data;

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
