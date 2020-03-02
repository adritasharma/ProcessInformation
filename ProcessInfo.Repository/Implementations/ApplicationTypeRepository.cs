using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Interfaces;

namespace ProcessInfo.Repository.Implementations
{
    public class ApplicationTypeRepository :  GenericRepository<ApplicationType>, IApplicationTypeRepository
    {
        public ApplicationTypeRepository(ProcessInfoDbContext context) : base(context)
        {

        }
    }
}
