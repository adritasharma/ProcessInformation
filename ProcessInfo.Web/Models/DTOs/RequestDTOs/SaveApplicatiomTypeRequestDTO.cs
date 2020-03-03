using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.Models.DTOs.RequestDTOs
{
    public class SaveApplicationTypeRequestDTO
    {
        public Guid? ApplicationTypeId { get; set; }
        public string ApplicationTypeName { get; set; }
        public string ApplicationTypeDescription { get; set; }
    }
}
