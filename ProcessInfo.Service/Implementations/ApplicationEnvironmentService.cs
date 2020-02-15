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
    
    public class ApplicationEnvironmentService : EntityService<ApplicationEnvironment>, IApplicationEnvironmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationEnvironmentRepository _applicationEnvironmentRepository;

        public ApplicationEnvironmentService(IUnitOfWork unitOfWork, IApplicationEnvironmentRepository repository) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationEnvironmentRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public ServiceResultModel<ApplicationEnvironment> Add(ApplicationEnvironment applicationEnvironment)
        {
            var res = new ServiceResultModel<ApplicationEnvironment> { IsSuccess = false, Errors = new List<string>() };

            if (!IsEnvironmentAvailable(applicationEnvironment.EnvironmentId, applicationEnvironment.ApplicationId))
            {
                res.Errors.Add("The ApplicationEnvironment Name is already present");
                return res;
            }


            _applicationEnvironmentRepository.Add(applicationEnvironment);
             UnitOfWork.Commit();

            res.IsSuccess = true;
            res.Data = applicationEnvironment;
;
            return res;
        }

        public ServiceResultModel<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResultModel<ApplicationEnvironment> Edit(ApplicationEnvironment applicationEnvironment)
        {
            var res = new ServiceResultModel<ApplicationEnvironment> { IsSuccess = false, Errors = new List<string>() };
            var applicationEnvironmentFromDB = _applicationEnvironmentRepository.FirstOrDefault(x => x.ApplicationEnvironmentId == applicationEnvironment.ApplicationEnvironmentId);


            if(applicationEnvironmentFromDB != null)
            {
                if (!IsEnvironmentAvailable(applicationEnvironment.EnvironmentId, applicationEnvironment.ApplicationId))
                {
                    res.Errors.Add("The ApplicationEnvironment Name is already present");
                    return res;
                }

                applicationEnvironmentFromDB.ApplicationId = applicationEnvironment.ApplicationId;
                applicationEnvironmentFromDB.ApplicationEnvironmentId = applicationEnvironment.ApplicationEnvironmentId;
                applicationEnvironmentFromDB.ServerPath = applicationEnvironment.ServerPath;
                applicationEnvironmentFromDB.AppPool = applicationEnvironment.AppPool;
                applicationEnvironmentFromDB.IISInstance = applicationEnvironment.IISInstance;
                applicationEnvironmentFromDB.VersionControlPath = applicationEnvironment.VersionControlPath;
                applicationEnvironmentFromDB.SiteUrl = applicationEnvironment.SiteUrl;
                applicationEnvironmentFromDB.ConfigFiles = applicationEnvironment.ConfigFiles;
                applicationEnvironmentFromDB.Database = applicationEnvironment.Database;

                _applicationEnvironmentRepository.Edit(applicationEnvironmentFromDB);

                UnitOfWork.Commit();

                res.IsSuccess = true;
                res.Data = applicationEnvironmentFromDB;
                return res;

            } else
            {
                res.Errors.Add("The ApplicationEnvironment Doesn't exist");
                return res;
            }


        }

        private bool IsEnvironmentAvailable(Guid environmentId, int applicationId)
        {
            if (_applicationEnvironmentRepository.Any(x => x.EnvironmentId == environmentId && x.ApplicationId == applicationId))
            {
                return false;
            } else
            {
                return true;
            }
        }

        public FilteredResultModel<List<ApplicationEnvironment>> GetFilteredApplicationEnvironments(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start = null, int? length = null)
        {
            Expression<Func<ApplicationEnvironment, bool>> deleg = null;
            if (!string.IsNullOrEmpty(searchText))
            {
                string rawPhoneNumber = searchText.Replace("-", "", StringComparison.InvariantCultureIgnoreCase);
                searchText = searchText.ToLower();
              //  deleg = x => x.EnvironmentId.ToLower().Contains(searchText);
            }

            IEnumerable<ApplicationEnvironment> query;
            //Implement OrderBy or OrderByDesc
            string defaultOrderBy = "ApplicationEnvironmentName";
            if (!string.IsNullOrEmpty(sortColumn) && sortColumn.ToLower() != "ApplicationEnvironmentId")
            {
                query = _applicationEnvironmentRepository.FindWithInclude(deleg, sortColumn, sortDirection, null, start, length);
            }
            {
                query =  _applicationEnvironmentRepository.FindWithInclude(deleg, defaultOrderBy, null, null, start, length);
            }

            return new FilteredResultModel<List<ApplicationEnvironment>>
            {
                Data = query.ToList(),
                TotalDataCount = _applicationEnvironmentRepository.Count(),
                FilteredDataCount = _applicationEnvironmentRepository.Count(deleg)
            };
        }

        public ApplicationEnvironment GetByApplicationEnvironmentId(int id)
        {
            return _applicationEnvironmentRepository.GetById(id);
        }

        public ServiceResultModel<bool> DeleteApplicationEnvironmentById(int id)
        {
            var res = new ServiceResultModel<bool> { IsSuccess = false, Errors = new List<string>() };

            var data = _applicationEnvironmentRepository.GetById(id);
            if (res == null)
            {
                res.Data = false;
                res.Errors.Add("The ApplicationEnvironment doesn't exists");
                return res;
            }

            _applicationEnvironmentRepository.Delete(data);
            UnitOfWork.Commit();

            res.Data = true;
            return res;
        }

    }
}
