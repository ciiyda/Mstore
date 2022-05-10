﻿using AppCore.Records.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class City:RecordBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }


        public List<UserDetails> UserDetails { get; set; }
    }
}