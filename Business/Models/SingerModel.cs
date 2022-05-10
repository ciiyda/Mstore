using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class SingerModel:RecordBase
    {
        [Required]
        [StringLength(20)]
        [DisplayName("Singer Name")]
        public string Name { get; set; }

        [DisplayName("Singer SurName")]
        [StringLength(30)]
        public string SurName { get; set; }

        public DateTime? BirthDate { get; set; }


        [DisplayName ("BirthDate")]
        public string BirthDateText { get; set; }


        [DisplayName("Album Count")]
        public int AlbumCount { get; set; }
    }
}
