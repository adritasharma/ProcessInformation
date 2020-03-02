using ProcessInfo.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProcessInfo.DB.Models
{
    public class ApplicationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ApplicationTypeId { get; set; }
        public string ApplicationTypeName { get; set; }
      //  public string ApplicationTypeDescription { get; set; }

      //  public virtual Application Application { get; set; }

    }
}
