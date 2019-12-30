using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessInfo.DB.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ProjectName { get; set; }
        public int WorkObjectName { get; set; }
        public string TeamMembers { get; set; }
        public string Status { get; set; }
        public string ApplicationType { get; set; }
        public int AddedByUserId { get; set; }
    }
}
