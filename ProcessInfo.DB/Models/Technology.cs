using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProcessInfo.DB.Models
{
    public class Technology
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public virtual ICollection<ApplicationTechnology> ApplicationTechnologys { get; set; }
    }
}
