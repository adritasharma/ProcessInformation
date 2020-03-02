using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessInfo.DB.Models;
using ProcessInfo.Service.Interfaces;
using ProcessInfo.Web.AutoMapperProfiles.RequestDTOs;
using ProcessInfo.Web.Models.DTOs.RequestDTOs;

namespace ProcessInfo.Web.Controllers
{
    [Route("api/applicationType")]
    [ApiController]
    public class ApplicationTypeController : ControllerBase
    {
        private readonly IApplicationTypeService _service;
        private readonly IMapper _mapper;

        public ApplicationTypeController(IApplicationTypeService applicationTypeService, IMapper mapper)
        {
            _service = applicationTypeService ?? throw new ArgumentNullException(nameof(applicationTypeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpPost]
        public IActionResult Add(SaveApplicationTypeRequestDTO applicationTypeDTO)
        {
            DB.Models.ApplicationType applicationType = _mapper.Map<DB.Models.ApplicationType>(applicationTypeDTO);

            var res =  _service.Add(applicationType);

            if (res.IsSuccess)
                return Ok(res.IsSuccess);
            else
                return BadRequest(res.Errors);
        }

        [DisableRequestSizeLimit]
        [HttpGet]
        public IActionResult Get(IDataTablesRequest request)
        {
            if (request == null)
            {
                var res =  _service.GetAll();
                return Ok(res);
            }
            else
            {
                var dtOptions = _mapper.Map<DataTablesRequestDTO>(request);

                var res =  _service.GetFilteredApplicationTypes(dtOptions.SearchText, dtOptions.FilterType, dtOptions.SortColumn, dtOptions.SortType, dtOptions.Start, dtOptions.Length);

                return Ok(DataTablesResponse.Create(request, res.TotalDataCount, res.FilteredDataCount, res.Data));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var res = _service.GetById(id);
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
           return Ok(_service.Delete(id));
        }

        [HttpPut]
        public async Task<IActionResult> Put(SaveApplicationTypeRequestDTO applicationTypeDTO)
        {
            DB.Models.ApplicationType applicationType = _mapper.Map<DB.Models.ApplicationType>(applicationTypeDTO);

            var res = _service.Edit(applicationType);

            if (res.IsSuccess)
                return Ok();
            else
                return BadRequest(res.Errors);
        }


    }
}