using AppCore.Records.Bases;
using Business.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
   public class AlbumModel:RecordBase
    {
        [Required]
        [StringLength(100)]
        [DisplayName("Album Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public double UnitePrice { get; set; }

        [DisplayName("Stock Amount")]
        [Range(0,int.MaxValue)]
        public int StockAmount { get; set; }

      
        public DateTime? Year { get; set; }

        [DisplayName("Number Of Discs")]
        [Range(0, 3)]
        public int NumberofDiscs { get; set; }

        [DisplayName("Singer Name")]
        public int SingerId { get; set; }

    
        [DisplayName("Unite Price")]
        [StringDecimal(ErrorMessage ="unit price must be numeric")]
        public string UnitePriceText { get; set; }


        [DisplayName("Album Year")]
        public string YearText { get; set; }

        public SingerModel Singer { get; set; }
    }
}
