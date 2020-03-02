using System;
using System.Collections.Generic;
using System.Text;
using ProcessInfo.DB.Models;
using ProcessInfo.Service.Models;
using ProcessInfo.Service.ServiceModels;
using ProcessInfo.Utility;

namespace ProcessInfo.Service.Interfaces
{
    public interface IApplicationTypeService
    {
        ServiceResultModel<ApplicationType> Add(ApplicationType File);
        ServiceResultModel<ApplicationType> Edit(ApplicationType File);
        ApplicationType GetById(Guid id);
        IEnumerable<ApplicationType> GetAll();
        ServiceResultModel<bool> Delete(Guid id);
        FilteredResultModel<List<ApplicationType>> GetFilteredApplicationTypes(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start, int? length);
    }
}
