using System;
using System.Collections.Generic;
using System.Text;
using ProcessInfo.DB.Models;
using ProcessInfo.Service.Models;

namespace ProcessInfo.Service.Interfaces
{
    public interface IApplicationService
    {
        ServiceResultModel<Application> Add(Application File);
        ServiceResultModel<Application> Edit(Application File);
        Application GetById(int id);
        IEnumerable<Application> GetAll();
        ServiceResultModel<bool> Delete(int id);
    }
}
