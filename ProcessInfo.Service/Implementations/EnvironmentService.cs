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
using Environment = ProcessInfo.DB.Models.Environment;

namespace ProcessInfo.Service.Implementations
{
    
    public class EnvironmentService : EntityService<Environment>, IEnvironmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnvironmentRepository _environmentRepository;

        public EnvironmentService(IUnitOfWork unitOfWork, IEnvironmentRepository repository) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _environmentRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public ServiceResultModel<Environment> Add(Environment environment)
        {
            var res = new ServiceResultModel<Environment> { IsSuccess = false, Errors = new List<string>() };

            if (!IsEnvironmentAvailable(environment.EnvironmentName, environment.EnvironmentDescription))
            {
                res.Errors.Add("The Environment Name is already present");
                return res;
            }


            _environmentRepository.Add(environment);
             UnitOfWork.Commit();

            res.IsSuccess = true;
            res.Data = environment;
;
            return res;
        }

        public ServiceResultModel<bool> Delete(Guid id)
        {
            var res = new ServiceResultModel<bool> { IsSuccess = false, Errors = new List<string>() };

            var data = _environmentRepository.GetById(id);
            if (res == null)
            {
                res.Data = false;
                res.Errors.Add("The Environment doesn't exists");
                return res;
            }

            _environmentRepository.Delete(data);
            UnitOfWork.Commit();

            res.Data = true;
            return res;
        }

        public ServiceResultModel<Environment> Edit(Environment environment)
        {
            var res = new ServiceResultModel<Environment> { IsSuccess = false, Errors = new List<string>() };
            var environmentFromDB = _environmentRepository.FirstOrDefault(x => x.EnvironmentId == environment.EnvironmentId);


            if(environmentFromDB != null)
            {
                if (!IsEnvironmentAvailable(environment.EnvironmentName, environment.EnvironmentDescription))
                {
                    res.Errors.Add("The Environment Name is already present");
                    return res;
                }

                environmentFromDB.EnvironmentId = environment.EnvironmentId;
                environmentFromDB.EnvironmentName = environment.EnvironmentName;
                environmentFromDB.EnvironmentDescription = environment.EnvironmentDescription;

                _environmentRepository.Edit(environmentFromDB);

                UnitOfWork.Commit();

                res.IsSuccess = true;
                res.Data = environmentFromDB;
                return res;

            } else
            {
                res.Errors.Add("The Environment Doesn't exist");
                return res;
            }


        }

        private bool IsEnvironmentAvailable(string environmentName, string environmentDesc)
        {
            if (_environmentRepository.Any(x => x.EnvironmentName == environmentName && x.EnvironmentDescription == environmentDesc))
            {
                return false;
            } else
            {
                return true;
            }
        }

        public FilteredResultModel<List<Environment>> GetFilteredEnvironments(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start = null, int? length = null)
        {
            Expression<Func<Environment, bool>> deleg = null;
            if (!string.IsNullOrEmpty(searchText))
            {
                string rawPhoneNumber = searchText.Replace("-", "", StringComparison.InvariantCultureIgnoreCase);
                searchText = searchText.ToLower();
              //  deleg = x => x.EnvironmentId.ToLower().Contains(searchText);
            }

            IEnumerable<Environment> query;
            //Implement OrderBy or OrderByDesc
            string defaultOrderBy = "EnvironmentName";
            if (!string.IsNullOrEmpty(sortColumn) && sortColumn.ToLower() != "EnvironmentId")
            {
                query = _environmentRepository.FindWithInclude(deleg, sortColumn, sortDirection, null, start, length);
            }
            {
                query =  _environmentRepository.FindWithInclude(deleg, defaultOrderBy, null, null, start, length);
            }

            return new FilteredResultModel<List<Environment>>
            {
                Data = query.ToList(),
                TotalDataCount = _environmentRepository.Count(),
                FilteredDataCount = _environmentRepository.Count(deleg)
            };
        }

        public Environment GetById(Guid id)
        {
            return _environmentRepository.GetById(id);
        }

        public ServiceResultModel<bool> DeleteEnvironmentById(int id)
        {
            var res = new ServiceResultModel<bool> { IsSuccess = false, Errors = new List<string>() };

            var data = _environmentRepository.GetById(id);
            if (res == null)
            {
                res.Data = false;
                res.Errors.Add("The Environment doesn't exists");
                return res;
            }

            _environmentRepository.Delete(data);
            UnitOfWork.Commit();

            res.Data = true;
            return res;
        }

    }
}
