using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Interfaces;
using ProcessInfo.Service.Interfaces;
using ProcessInfo.Service.Models;
using System;
using System.Collections.Generic;
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

        public ServiceResultModel<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResultModel<Application> Edit(Application application)
        {
            var res = new ServiceResultModel<Application> { IsSuccess = false, Errors = new List<string>() };
            var applicationFromDB = _applicationRepository.FirstOrDefault(x => x.ApplicationId == application.ApplicationId);


            if(applicationFromDB != null)
            {
                if (!IsApplicationNameAvailable(application.ApplicationName))
                {
                    res.Errors.Add("The Application Name is already present");
                    return res;
                }


                applicationFromDB.ApplicationName = application.ApplicationName.Trim();

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

    }
}
