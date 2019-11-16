using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

using ProcessInfo.Repository.Interfaces;

namespace ProcessInfo.Repository.Implementations
{
    public class UserRepository :  GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProcessInfoDbContext context) : base(context)
        {

        }
    }
}
