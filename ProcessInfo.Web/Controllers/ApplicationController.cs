using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessInfo.DB.Models;
using ProcessInfo.Service.Interfaces;
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

    }
}