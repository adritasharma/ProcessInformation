using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessInfo.DB.Models
{
    public class Environment
    {
        public Guid EnvironmentId { get; set; }
        public string EnvironmentName { get; set; }
        public string EnvironmentDescription { get; set; }
    }
}
