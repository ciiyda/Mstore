using AppCore.Records.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Country:RecordBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public List<City> Cities { get; set; }

        public List<UserDetails> UserDetails { get; set; }

    }
}