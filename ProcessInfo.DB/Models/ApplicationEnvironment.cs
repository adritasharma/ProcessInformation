using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProcessInfo.DB.Models
{
    public class ApplicationEnvironment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ApplicationEnvironmentId { get; set; }
        public string ServerPath { get; set; }
        public string AppPool { get; set; }
        public string IISInstance { get; set; }
        public string VersionControlPath { get; set; }
        public string SiteUrl { get; set; }
        public string ConfigFiles { get; set; }
        public string Database { get; set; }
        public Guid ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }
       public Guid EnvironmentId { get; set; }

        [ForeignKey("EnvironmentId")]
        public Environment Environment { get; set; }

    }
}
