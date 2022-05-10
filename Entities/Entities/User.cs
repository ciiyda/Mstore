using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class User:RecordBase
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get;set; }

        public Role Role { get; set; }

        public int UserDetailsId { get; set; }

        public UserDetails UserDetail { get; set; }
    }
}
