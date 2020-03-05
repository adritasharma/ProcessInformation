using System;
using System.Collections.Generic;
using System.Text;
using ProcessInfo.Service.Models;
using ProcessInfo.DB.Models;
using ProcessInfo.Service.ServiceModels;
using ProcessInfo.Utility;

namespace ProcessInfo.Service.Interfaces
{
    public interface IUserService
    {
        ServiceResultModel<User> Add(User entity);
        ServiceResultModel<User> Edit(User entity);
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        ServiceResultModel<bool> Delete(Guid id);
        IEnumerable<User> SearchUserByKeyword(string keyword);
        User GetUserByUsername(string username);

        FilteredResultModel<List<User>> GetFilteredUsers(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start = null, int? length = null);

    }
}
