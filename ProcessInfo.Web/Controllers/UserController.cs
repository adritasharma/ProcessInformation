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
using System.IO;
using OfficeOpenXml;
using ProcessInfo.Web.Helper;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

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

            var res = _service.Add(user);

            if (res.IsSuccess)
                return Ok(res.IsSuccess);
            else
                return BadRequest(res.Errors);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequestDTO loginDTO)
        {
            User user = _service.GetUserByUsername(loginDTO.Username);

            if (user == null)
            {
                return BadRequest("Invalid username/password combination");
            }
            else
            {
                if(!IsPasswordValid(loginDTO.Password, user.PasswordHash,user.PasswordSalt))
                {
                    return BadRequest("Invalid username/password combination");
                } else
                {
                    return Ok(_mapper.Map<LoginResponseDTO>(user));
                }

            }

        }

        [DisableRequestSizeLimit]
        [HttpGet]
        public IActionResult Get(IDataTablesRequest request)
        {
            if (request == null)
            {
                var res = _service.GetAll();
                return Ok(res);
            }
            else
            {
                var dtOptions = _mapper.Map<DataTablesRequestDTO>(request);

                var res = _service.GetFilteredUsers(dtOptions.SearchText, dtOptions.FilterType, dtOptions.SortColumn, dtOptions.SortType, dtOptions.Start, dtOptions.Length);

                return Ok(DataTablesResponse.Create(request, res.TotalDataCount, res.FilteredDataCount, _mapper.Map<List<UserResponseDTO>>(res.Data)));
            }
        }

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

        [HttpGet]
        [Route("search/{keyword}")]
        public IActionResult SearchUserByKeyword(string keyword)
        {
            var res = _service.SearchUserByKeyword(keyword);
            return Ok(_mapper.Map<List<UserResponseDTO>>(res));
        }
        [HttpPost]
        [Route("bulk-upload-users")]
        public async Task<ActionResult> BulkUploadUsers([FromForm]BulkUploadUserRequestDTO fileUpload)
        {
            var errors = new List<string>();
            var file = Request.Form.Files[0];

            var users = new List<SaveUserRequestDTO>();

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);
                using (var package = new ExcelPackage(memoryStream))
                {
                    var worksheet = package.Workbook.Worksheets[1]; // Tip: To access the first worksheet, try index 1, not 0
                    users.AddRange(ExcelHelper.ReadExcelForBulkUploadUser(package, worksheet));
                }
            }
            //Validate the data

            var validationErrors = ValidateUser(users);
            if (validationErrors != null && validationErrors.Any())
                return Ok(new { SavedRecord = new List<UserResponseDTO>(), Errors = validationErrors });

            //If we come so far, then we the correct data in place. Try Storing them.
            // var addedUsers = new List<UserResponseDTO>();
            var addedUsers = new List<User>();

            var errorsWhileSavingData = new List<string>();
            int row = 2;
            //var bulkUploadId = Guid.NewGuid();
            foreach (var user in users)
            {
                var result = _service.Add(_mapper.Map<User>(user));

                if (result.IsSuccess)
                    //   addedUsers.Add(_mapper.Map<UserResponseDTO>(result.Data));

                    addedUsers.Add(result.Data);
                else
                    errorsWhileSavingData.Add($"{string.Join(", ", result.Errors)} for Row # {row}");

                row++;
            }

            //BulkUploadNotificationEmailModel emailModel = new BulkUploadNotificationEmailModel()
            //{
            //    FullName = "",
            //    AddedCaseCount = addedCandidates.Count
            //};

            //List<string> emailIds = _configuration.GetSection("KeyValuePairs").GetValue<string>("BulkUploadNotificationEmailIds").Split(",").ToList();

            //foreach (string emailId in emailIds)
            //{
            //    var emailRes = _email.SendEmail(emailModel, "_BulkUploadComplete", "Bulk Upload Notification", "Bulk Upload Notification", emailId, null, null, null, null);
            //}

            return Ok(new { SavedRecord = addedUsers, Errors = errorsWhileSavingData });
        }

        private List<string> ValidateUser(List<SaveUserRequestDTO> candidates)
        {
            var errors = new List<string>();
            if (candidates != null && candidates.Any())
            {
                int row = 2;
                foreach (var candidate in candidates)
                {
                    var context = new System.ComponentModel.DataAnnotations.ValidationContext(candidate, serviceProvider: null, items: null);
                    var results = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(candidate, context, results);

                    if (!isValid)
                    {
                        foreach (var validationResult in results)
                        {
                            errors.Add($"{validationResult.ErrorMessage} - On Row #{row}");
                        }
                    }
                    row++;
                }
            }
            return errors;
        }

        [Route("downloadSampleBulkUserUploadFile")]
        public async Task<IActionResult> DownloadSample()
        {

            //Download the sample report here. 
            var file = Path.Combine(Directory.GetCurrentDirectory(),
                            "StaticDocuments", "Sheets", "ExcelSheetForBulkUpload.xlsx");

            return PhysicalFile(file, "application/vnd.ms-excel", "SampleSheetForUpload.xlsx");
        }

        private bool IsPasswordValid(string password, string passwordHash, string passwordSalt)
        {
            using (var hash = SHA512.Create())
            {
                var saltedPlainTextBytes = Encoding.UTF8.GetBytes(password).Concat(Convert.FromBase64String(passwordSalt)).ToArray();
                var hashedBytes = hash.ComputeHash(saltedPlainTextBytes);
                return hashedBytes.SequenceEqual(Convert.FromBase64String(passwordHash));
            }
        }
    }
}