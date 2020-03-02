using ProcessInfo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.Models.DTOs.RequestDTOs
{
    public class SaveApplicationRequestDTO
    {
        public Guid? ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ProjectName { get; set; }
        public int WorkObjectName { get; set; }
        public List<SaveUserRequestDTO> TeamMembers { get; set; }
        public string Status { get; set; }
        public Guid ApplicationTypeId { get; set; }

    }
}
