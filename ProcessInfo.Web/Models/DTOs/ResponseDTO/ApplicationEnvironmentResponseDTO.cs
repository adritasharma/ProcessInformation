﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessInfo.Web.Models.DTOs.ResponseDTO
{
    public class ApplicationEnvironmentResponseDTO
    {
        public Guid ApplicationEnvironmentId { get; set; }
        public Guid EnvironmentId { get; set; }
        public string ServerPath { get; set; }
        public string AppPool { get; set; }
        public string IISInstance { get; set; }
        public string VersionControlPath { get; set; }
        public string SiteUrl { get; set; }
        public string ConfigFiles { get; set; }
        public string Database { get; set; }
        public Guid ApplicationId { get; set; }
        public string EnvironmentName { get; set; }
        public string Port { get; set; }

    }
}
