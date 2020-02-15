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
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _service;
        private readonly IMapper _mapper;

        public ApplicationController(IApplicationService applicationService, IMapper mapper)
        {
            _service = applicationService ?? throw new ArgumentNullException(nameof(applicationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpPost]
        public IActionResult Add(SaveApplicationRequestDTO applicationDTO)
        {
            Application application = _mapper.Map<Application>(applicationDTO);

            var res =  _service.Add(application);

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

                var res =  _service.GetFilteredApplications(dtOptions.SearchText, dtOptions.FilterType, dtOptions.SortColumn, dtOptions.SortType, dtOptions.Start, dtOptions.Length);

                return Ok(DataTablesResponse.Create(request, res.TotalDataCount, res.FilteredDataCount, res.Data));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var res = _service.GetById(id);
            return Ok(res);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
           return Ok(_service.Delete(id));
        }

        [HttpPut]
        public async Task<IActionResult> Put(SaveApplicationEnvironmentRequestDTO applicationDTO)
        {
            Application application = _mapper.Map<Application>(applicationDTO);

            var res = _service.Edit(application);

            if (res.IsSuccess)
                return Ok();
            else
                return BadRequest(res.Errors);
        }

    }
}