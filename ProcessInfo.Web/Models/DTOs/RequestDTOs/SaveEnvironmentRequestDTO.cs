using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.Models.DTOs.RequestDTOs
{
    public class SaveEnvironmentRequestDTO
    {
        //public Guid EnvironmentId { get; set; }
        public string EnvironmentName { get; set; }
        public string EnvironmentDescription { get; set; }
    }
}
