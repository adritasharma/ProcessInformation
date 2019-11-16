using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessInfo.DB.Models
{
    public  class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
