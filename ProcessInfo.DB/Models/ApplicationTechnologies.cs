using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProcessInfo.DB.Models
{
    public class ApplicationTechnology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ApplicationTechnologyId { get; set; }
        public string ApplicationId { get; set; }
        public string TechnologyId { get; set; }
        [ForeignKey("TechnologyId")]
        public Technology Technology { get; set; }
    }
}
