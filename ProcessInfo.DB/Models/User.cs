using ProcessInfo.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessInfo.DB.Models
{
    public  class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Role Role { get; set; }
        public string FullName() => (!string.IsNullOrEmpty(MiddleName)) ? $"{FirstName} {MiddleName} {LastName}"?.Trim() : $"{FirstName} {LastName}";
        public string ReverseFullName() => (!string.IsNullOrEmpty(MiddleName)) ? $"{LastName} {MiddleName} {FirstName}"?.Trim() : $"{LastName} {FirstName}";

    }
}
