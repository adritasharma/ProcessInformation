using System;
using System.Collections.Generic;
using System.Text;
using ProcessInfo.DB.Models;
using ProcessInfo.Service.Models;
using ProcessInfo.Service.ServiceModels;
using ProcessInfo.Utility;

namespace ProcessInfo.Service.Interfaces
{
    public interface IApplicationEnvironmentService
    {
        ServiceResultModel<ApplicationEnvironment> Add(ApplicationEnvironment File);
        ServiceResultModel<ApplicationEnvironment> Edit(ApplicationEnvironment File);
        ApplicationEnvironment GetById(Guid id);
        IEnumerable<ApplicationEnvironment> GetAll();
        ServiceResultModel<bool> Delete(Guid id);
        FilteredResultModel<List<ApplicationEnvironment>> GetFilteredApplicationEnvironments(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start = null, int? length = null);
    }
}
