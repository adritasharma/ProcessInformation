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
    
    public class ApplicationService : EntityService<Application>, IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IUnitOfWork unitOfWork, IApplicationRepository repository) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public ServiceResultModel<Application> Add(Application application)
        {
            var res = new ServiceResultModel<Application> { IsSuccess = false, Errors = new List<string>() };

            if (!IsApplicationNameAvailable(application.ApplicationName))
            {
                res.Errors.Add("The Application Name is already present");
                return res;
            }


            _applicationRepository.Add(application);
             UnitOfWork.Commit();

            res.IsSuccess = true;
            res.Data = application;
;
            return res;
        }

        public ServiceResultModel<bool> Delete(Guid id)
        {
            var res = new ServiceResultModel<bool> { IsSuccess = false, Errors = new List<string>() };

            var data = _applicationRepository.GetById(id);
            if (res == null)
            {
                res.Data = false;
                res.Errors.Add("The Application doesn't exists");
                return res;
            }

            _applicationRepository.Delete(data);
            UnitOfWork.Commit();

            res.Data = true;
            return res;
        }

        public ServiceResultModel<Application> Edit(Application application)
        {
            var res = new ServiceResultModel<Application> { IsSuccess = false, Errors = new List<string>() };
            var applicationFromDB = _applicationRepository.FirstOrDefault(x => x.ApplicationId == application.ApplicationId);


            if(applicationFromDB != null)
            {
                //if (!IsApplicationNameAvailable(application.ApplicationName))
                //{
                //    res.Errors.Add("The Application Name is already present");
                //    return res;
                //}


                applicationFromDB.ApplicationName = application.ApplicationName.TrimSpace();
                applicationFromDB.ProjectName = application.ProjectName.TrimSpace();
                applicationFromDB.WorkObjectName = application.WorkObjectName;
                applicationFromDB.TeamMembers = application.TeamMembers;
                applicationFromDB.Status = application.Status.TrimSpace();
                applicationFromDB.ApplicationType = application.ApplicationType.TrimSpace();

                _applicationRepository.Edit(applicationFromDB);

                UnitOfWork.Commit();

                res.IsSuccess = true;
                res.Data = applicationFromDB;
                return res;

            } else
            {
                res.Errors.Add("The Application Doesn't exist");
                return res;
            }


        }

        private bool IsApplicationNameAvailable(string applicationName)
        {
            if (_applicationRepository.Any(x => x.ApplicationName.ToLower() == applicationName.ToLower()))
            {
                return false;
            } else
            {
                return true;
            }
        }

        public FilteredResultModel<List<Application>> GetFilteredApplications(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start = null, int? length = null)
        {
            Expression<Func<Application, bool>> deleg = null;
            if (!string.IsNullOrEmpty(searchText))
            {
                string rawPhoneNumber = searchText.Replace("-", "", StringComparison.InvariantCultureIgnoreCase);
                searchText = searchText.ToLower();
                deleg = x => x.ApplicationName.ToLower().Contains(searchText);
            }

            //Role if we do have a filterType (We mostly filter them by Roles)

            IEnumerable<Application> query;
            //Implement OrderBy or OrderByDesc
            string defaultOrderBy = "ApplicationName";
            if (!string.IsNullOrEmpty(sortColumn) && sortColumn.ToLower() != "ApplicationId")
            {
                query = _applicationRepository.FindWithInclude(deleg, sortColumn, sortDirection, null, start, length);
            }
            {
                query =  _applicationRepository.FindWithInclude(deleg, defaultOrderBy, null, null, start, length);
            }

            return new FilteredResultModel<List<Application>>
            {
                Data = query.ToList(),
                TotalDataCount = _applicationRepository.Count(),
                FilteredDataCount = _applicationRepository.Count(deleg)
            };
        }

        public Application GetByApplicationId(Guid id)
        {
            return _applicationRepository.FirstOrDefaultWithInclude(x => x.ApplicationId == id, y => y.Include(cc => cc.ApplicationEnvironments).ThenInclude(zz => zz.Environment));
        }

        public ServiceResultModel<bool> DeleteApplicationById(int id)
        {
            var res = new ServiceResultModel<bool> { IsSuccess = false, Errors = new List<string>() };

            var data = _applicationRepository.GetById(id);
            if (res == null)
            {
                res.Data = false;
                res.Errors.Add("The Application doesn't exists");
                return res;
            }

            _applicationRepository.Delete(data);
            UnitOfWork.Commit();

            res.Data = true;
            return res;
        }

    }
}
