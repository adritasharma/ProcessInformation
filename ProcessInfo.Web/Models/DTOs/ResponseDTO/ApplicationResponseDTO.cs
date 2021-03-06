﻿using ProcessInfo.DB.Models;
using ProcessInfo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.Models.DTOs.ResponseDTO
{
    public class ApplicationResponseDTO
    {
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ProjectName { get; set; }
        public int WorkObjectName { get; set; }
        public string TeamMemberNames { get; set; }
        public string Status { get; set; }
        public Guid ApplicationTypeId { get; set; }
        public string ApplicationTypeName { get; set; }
        public ProjectType ProjectType { get; set; }
        public string ProjectTypeName { get; set; }

        public List<UserResponseDTO> TeamMembers { get; set; }
        public List<ApplicationEnvironmentResponseDTO> ApplicationEnvironments { get; set; }
    }
}
