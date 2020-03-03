using Microsoft.EntityFrameworkCore;
using ProcessInfo.DB;
using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Interfaces;
using ProcessInfo.Service.Interfaces;
using ProcessInfo.Service.Models;
using ProcessInfo.Service.ServiceModels;
using ProcessInfo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ProcessInfo.Service.Implementations
{
    
    public class UserService : EntityService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public ServiceResultModel<User> Add(User user)
        {
            var res = new ServiceResultModel<User> { IsSuccess = false, Errors = new List<string>() };

            if (!IsUserNameAvailable(user.Username))
            {
                res.Errors.Add("The User Name is already taken");
                return res;
            }
            if (!IsEmailAddressAvailable(user.Username))
            {
                res.Errors.Add("The Email Address is already registered");
                return res;
            }


            _userRepository.Add(user);
             UnitOfWork.Commit();

            res.IsSuccess = true;
            res.Data = user;
;
            return res;
        }

        public ServiceResultModel<bool> Delete(Guid id)
        {
            var res = new ServiceResultModel<bool> { IsSuccess = false, Errors = new List<string>() };

            var data = _userRepository.GetById(id);
            if (res == null)
            {
                res.Data = false;
                res.Errors.Add("The User doesn't exists");
                return res;
            }

            _userRepository.Delete(data);
            UnitOfWork.Commit();

            res.Data = true;
            return res;
        }

        public ServiceResultModel<User> Edit(User user)
        {
            var res = new ServiceResultModel<User> { IsSuccess = false, Errors = new List<string>() };
            var userFromDB = _userRepository.FirstOrDefault(x => x.UserId == user.UserId);


            if(userFromDB != null)
            {
                //if (!IsUserNameAvailable(user.UserName))
                //{
                //    res.Errors.Add("The User Name is already present");
                //    return res;
                //}


                userFromDB.FirstName = user.FirstName.TrimSpace();
                userFromDB.MiddleName = user.MiddleName.TrimSpace();
                userFromDB.LastName = user.LastName.TrimSpace();
                userFromDB.EmailAddress = user.EmailAddress.TrimSpace();

                _userRepository.Edit(userFromDB);

                UnitOfWork.Commit();

                res.IsSuccess = true;
                res.Data = userFromDB;
                return res;

            } else
            {
                res.Errors.Add("The User Doesn't exist");
                return res;
            }


        }

        private bool IsUserNameAvailable(string userName)
        {
            if (_userRepository.Any(x => x.Username.ToLower() == userName.ToLower()))
            {
                return false;
            } else
            {
                return true;
            }
        }
        private bool IsEmailAddressAvailable(string email)
        {
            if (_userRepository.Any(x => x.EmailAddress.ToLower() == email.ToLower()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public FilteredResultModel<List<User>> GetFilteredUsers(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start = null, int? length = null)
        {
            Expression<Func<User, bool>> deleg = null;
            if (!string.IsNullOrEmpty(searchText))
            {
                string rawPhoneNumber = searchText.Replace("-", "", StringComparison.InvariantCultureIgnoreCase);
                searchText = searchText.ToLower();
                deleg = x => x.Username.ToLower().Contains(searchText);
            }

            //Role if we do have a filterType (We mostly filter them by Roles)

            IEnumerable<User> query;
            //Implement OrderBy or OrderByDesc
            string defaultOrderBy = "UserName";
            if (!string.IsNullOrEmpty(sortColumn) && sortColumn.ToLower() != "UserId")
            {
                query = _userRepository.FindWithInclude(deleg, sortColumn, sortDirection, null, start, length);
            }
            {
                query =  _userRepository.FindWithInclude(deleg, defaultOrderBy, null, null, start, length);
            }
            return new FilteredResultModel<List<User>>
            {
                Data = query.ToList(),
                TotalDataCount = _userRepository.Count(),
                FilteredDataCount = _userRepository.Count(deleg)
            };
        }

        public User GetById(Guid id)
        {
            return _userRepository.FirstOrDefaultWithInclude(x => x.UserId == id);
        }

        public ServiceResultModel<bool> DeleteUserById(int id)
        {
            var res = new ServiceResultModel<bool> { IsSuccess = false, Errors = new List<string>() };

            var data = _userRepository.GetById(id);
            if (res == null)
            {
                res.Data = false;
                res.Errors.Add("The User doesn't exists");
                return res;
            }

            _userRepository.Delete(data);
            UnitOfWork.Commit();

            res.Data = true;
            return res;
        }

        public IEnumerable<User> SearchUserByKeyword(string keyword)
        {
            return _userRepository.FindWithInclude(x => x.FirstName.Contains(keyword) || x.LastName.Contains(keyword) || x.Username.Contains(keyword) || x.EmailAddress.Contains(keyword));
        }
    }
}
