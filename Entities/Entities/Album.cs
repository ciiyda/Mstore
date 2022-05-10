using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Album:RecordBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength (500)]
        public string Description { get; set; }

        public double UnitePrice { get; set; }

        public int StockAmount { get; set; }

        public DateTime? Year {get; set; }

        public int NumberofDiscs { get; set; }

        public int SingerId { get; set; }

        public Singer Singer { get; set; }



    }
}
