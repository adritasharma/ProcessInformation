using System;
using System.Collections.Generic;
using System.Text;
using ProcessInfo.Service.Models;
using ProcessInfo.DB.Models;

namespace ProcessInfo.Service.Interfaces
{
    public interface IRoleService
    {
        ServiceResultModel<Role> Add(Role fileType);
        ServiceResultModel<Role> Edit(Role fileType);
        Role GetById(Guid id);
        IEnumerable<Role> GetAll();
        bool Delete(Guid id);
    }
}
