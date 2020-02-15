using System;
using System.Collections.Generic;
using System.Text;
using ProcessInfo.DB.Models;
using ProcessInfo.Service.Models;
using ProcessInfo.Service.ServiceModels;
using ProcessInfo.Utility;

namespace ProcessInfo.Service.Interfaces
{
    public interface IEnvironmentService
    {
        ServiceResultModel<DB.Models.Environment> Add(DB.Models.Environment File);
        ServiceResultModel<DB.Models.Environment> Edit(DB.Models.Environment File);
        DB.Models.Environment GetById(int id);
        IEnumerable<DB.Models.Environment> GetAll();
        ServiceResultModel<bool> Delete(int id);
        FilteredResultModel<List<DB.Models.Environment>> GetFilteredEnvironments(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start = null, int? length = null);
    }
}
