using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Interfaces;

namespace ProcessInfo.Repository.Implementations
{
    public class EnvironmentRepository :  GenericRepository<Environment>, IEnvironmentRepository
    {
        public EnvironmentRepository(ProcessInfoDbContext context) : base(context)
        {

        }
    }
}
