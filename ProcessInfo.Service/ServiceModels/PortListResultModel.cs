using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessInfo.Service.ServiceModels
{
    public class PortListResultModel
    {
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string EnvironmentName { get; set; }
        public Guid EnvironmentId { get; set; }

        public string SiteUrl { get; set; }
        public string Port { get; set; }
    }
}
