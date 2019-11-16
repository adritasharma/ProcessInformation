using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessInfo.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
