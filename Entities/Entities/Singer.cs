using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Singer: RecordBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(30)]
        public string SurName { get; set; }

        public DateTime? BirthDate { get; set; }

        public List<Album> Albums { get; set; }

    }
}
