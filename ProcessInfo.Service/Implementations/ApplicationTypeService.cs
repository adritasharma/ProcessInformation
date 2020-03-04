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
    
    public class ApplicationTypeService : EntityService<ApplicationType>, IApplicationTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationTypeRepository _applicationTypeRepository;

        public ApplicationTypeService(IUnitOfWork unitOfWork, IApplicationTypeRepository repository) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationTypeRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public ServiceResultModel<ApplicationType> Add(ApplicationType applicationType)
        {
            var res = new ServiceResultModel<ApplicationType> { IsSuccess = false, Errors = new List<string>() };

            if (!IsApplicationTypeNameAvailable(applicationType.ApplicationTypeName))
            {
                res.Errors.Add("The Application Type Name is already present");
                return res;
            }


            _applicationTypeRepository.Add(applicationType);
             UnitOfWork.Commit();

            res.IsSuccess = true;
            res.Data = applicationType;
;
            return res;
        }

        public ServiceResultModel<bool> Delete(Guid id)
        {
            var res = new ServiceResultModel<bool> { IsSuccess = false, Errors = new List<string>() };

            var data = _applicationTypeRepository.GetById(id);
            if (res == null)
            {
                res.Data = false;
                res.Errors.Add("The Application Type doesn't exists");
                return res;
            }

            _applicationTypeRepository.Delete(data);
            UnitOfWork.Commit();

            res.Data = true;
            return res;
        }

        public ServiceResultModel<ApplicationType> Edit(ApplicationType applicationType)
        {
            var res = new ServiceResultModel<ApplicationType> { IsSuccess = false, Errors = new List<string>() };
            var applicationTypeFromDB = _applicationTypeRepository.FirstOrDefault(x => x.ApplicationTypeId == applicationType.ApplicationTypeId);


            if(applicationTypeFromDB != null)
            {
                //if (!IsApplicationTypeNameAvailable(applicationType.ApplicationTypeName))
                //{
                //    res.Errors.Add("The ApplicationType Name is already present");
                //    return res;
                //}


                applicationTypeFromDB.ApplicationTypeName = applicationType.ApplicationTypeName.TrimSpace();
                applicationTypeFromDB.ApplicationTypeDescription = applicationType.ApplicationTypeDescription.TrimSpace();

                _applicationTypeRepository.Edit(applicationTypeFromDB);

                UnitOfWork.Commit();

                res.IsSuccess = true;
                res.Data = applicationTypeFromDB;
                return res;

            } else
            {
                res.Errors.Add("The ApplicationType Doesn't exist");
                return res;
            }


        }

        private bool IsApplicationTypeNameAvailable(string applicationTypeName)
        {
            if (_applicationTypeRepository.Any(x => x.ApplicationTypeName.ToLower() == applicationTypeName.ToLower()))
            {
                return false;
            } else
            {
                return true;
            }
        }

        public FilteredResultModel<List<ApplicationType>> GetFilteredApplicationTypes(string searchText, string filterType, string sortColumn, FCSortDirection sortDirection, int? start = null, int? length = null)
        {
            Expression<Func<ApplicationType, bool>> deleg = null;
            if (!string.IsNullOrEmpty(searchText))
            {
                string rawPhoneNumber = searchText.Replace("-", "", StringComparison.InvariantCultureIgnoreCase);
                searchText = searchText.ToLower();
                //  deleg = x => x.ApplicationTypeId.ToLower().Contains(searchText);
            }

            IEnumerable<ApplicationType> query;
            //Implement OrderBy or OrderByDesc
            string defaultOrderBy = "ApplicationTypeName";
            if (!string.IsNullOrEmpty(sortColumn) && sortColumn.ToLower() != "ApplicationTypeId")
            {
                query = _applicationTypeRepository.FindWithInclude(deleg, sortColumn, sortDirection, null, start, length);
            }
            else
            {
                query = _applicationTypeRepository.FindWithInclude(deleg, defaultOrderBy, null, null, start, length);
            }

            return new FilteredResultModel<List<ApplicationType>>
            {
                Data = query.ToList(),
                TotalDataCount = _applicationTypeRepository.Count(),
                FilteredDataCount = _applicationTypeRepository.Count(deleg)
            };
        }

        public ApplicationType GetById(Guid id)
        {
            return _applicationTypeRepository.FirstOrDefaultWithInclude(x => x.ApplicationTypeId == id);

        }
     
    }
}
