using System;
using System.Collections.Generic;
using System.Text;
using ProcessInfo.DB.Models;
using ProcessInfo.Service.Models;
using ProcessInfo.Service.ServiceModels;
using ProcessInfo.Utility;

namespace ProcessInfo.Service.Interfaces
{
    public interface IApplicationService
    {
        ServiceResultModel<Application> Add(Application File);
        ServiceResultModel<Application> Edit(Application File);
        Application GetByApplicationId(Guid id);
        IEnumerable<Application> GetAll();
        ServiceResultModel<bool> Delete(Guid id);
        FilteredResultModel<List<Application>> GetFilteredApplications(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start = null, int? length = null);
    }
}
