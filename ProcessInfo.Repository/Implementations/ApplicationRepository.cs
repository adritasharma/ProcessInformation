using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Interfaces;

namespace ProcessInfo.Repository.Implementations
{
    public class ApplicationRepository :  GenericRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(ProcessInfoDbContext context) : base(context)
        {

        }
    }
}
