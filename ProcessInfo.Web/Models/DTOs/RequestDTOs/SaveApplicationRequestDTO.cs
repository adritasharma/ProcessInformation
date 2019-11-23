using ProcessInfo.DB;
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
        public HostEnvironment EnvironmentId { get; set; }
        public string ServerPath { get; set; }
        public string AppPool { get; set; }
        public string IISInstance { get; set; }
        public string VersionControlPath { get; set; }
        public string SiteUrl { get; set; }
        public string ConfigFiles { get; set; }
        public string Database { get; set; }
    }
}
