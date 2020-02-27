using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.Models.DTOs.RequestDTOs
{
    public class BulkUploadUserRequestDTO
    {
        public IFormFile Upload { get; set; }

    }
}
