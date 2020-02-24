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
using ProcessInfo.Web.Models.DTOs.ResponseDTO;

namespace ProcessInfo.Web.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _service = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpPost]
        public IActionResult Add(SaveUserRequestDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);

            var res =  _service.Add(user);

            if (res.IsSuccess)
                return Ok(res.IsSuccess);
            else
                return BadRequest(res.Errors);
        }

        //[DisableRequestSizeLimit]
        //[HttpGet]
        //public IActionResult Get(IDataTablesRequest request)
        //{
        //    if (request == null)
        //    {
        //        var res =  _service.GetAll();
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        var dtOptions = _mapper.Map<DataTablesRequestDTO>(request);

        //        var res =  _service.GetFilteredUsers(dtOptions.SearchText, dtOptions.FilterType, dtOptions.SortColumn, dtOptions.SortType, dtOptions.Start, dtOptions.Length);

        //        return Ok(DataTablesResponse.Create(request, res.TotalDataCount, res.FilteredDataCount, res.Data));
        //    }
        //}

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            User res = _service.GetById(id);
            return Ok(_mapper.Map<UserResponseDTO>(res));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
           return Ok(_service.Delete(id));
        }

        [HttpPut]
        public async Task<IActionResult> Put(SaveUserRequestDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);

            var res = _service.Edit(user);

            if (res.IsSuccess)
                return Ok();
            else
                return BadRequest(res.Errors);
        }

    }
}