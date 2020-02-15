using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.Models.DTOs.RequestDTOs
{
    public class SaveApplicationEnvironmentRequestDTO
    {
        public int ApplicationEnvironmentId { get; set; }
        public Guid EnvironmentId { get; set; }
        public string ServerPath { get; set; }
        public string AppPool { get; set; }
        public string IISInstance { get; set; }
        public string VersionControlPath { get; set; }
        public string SiteUrl { get; set; }
        public string ConfigFiles { get; set; }
        public string Database { get; set; }
        public int ApplicationId { get; set; }
    }
}
