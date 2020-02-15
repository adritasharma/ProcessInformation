using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Interfaces;

namespace ProcessInfo.Repository.Implementations
{
    public class ApplicationEnvironmentRepository :  GenericRepository<ApplicationEnvironment>, IApplicationEnvironmentRepository
    {
        public ApplicationEnvironmentRepository(ProcessInfoDbContext context) : base(context)
        {

        }
    }
}
