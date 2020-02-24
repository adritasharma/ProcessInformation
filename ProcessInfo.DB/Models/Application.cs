using ProcessInfo.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProcessInfo.DB.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ProjectName { get; set; }
        public int WorkObjectName { get; set; }
        public string TeamMembers { get; set; }
        public string Status { get; set; }
        public string ApplicationType { get; set; }
        public string TechnologiesUsed { get; set; }
        public ProjectType ProjectType { get; set; }
        public virtual ICollection<ApplicationEnvironment> ApplicationEnvironments { get; set; }
    }
}
