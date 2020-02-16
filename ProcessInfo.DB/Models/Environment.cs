using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProcessInfo.DB.Models
{
    public class Environment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EnvironmentId { get; set; }
        public string EnvironmentName { get; set; }
        public string EnvironmentDescription { get; set; }
        public virtual ICollection<ApplicationEnvironment> ApplicationEnvironments { get; set; }

    }
}
