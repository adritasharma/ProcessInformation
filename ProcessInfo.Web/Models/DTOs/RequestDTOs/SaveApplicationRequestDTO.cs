using ProcessInfo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.Models.DTOs.RequestDTOs
{
    public class SaveApplicationRequestDTO
    {
        public string ApplicationName { get; set; }
        public string ProjectName { get; set; }
        public int WorkObjectName { get; set; }
        public string TeamMembers { get; set; }
        public string Status { get; set; }
        public string ApplicationType { get; set; }
    }
}
