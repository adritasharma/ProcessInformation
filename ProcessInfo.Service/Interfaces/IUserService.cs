using System;
using System.Collections.Generic;
using System.Text;
using ProcessInfo.Service.Models;
using ProcessInfo.DB.Models;

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
    }
}
