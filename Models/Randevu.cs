using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Randevu_Sistemi.Models
{
    public class Randevu
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RandevuID { get; set; }

        public string HastaTCNo { get; set; }
        [ForeignKey("HastaTCNo")]
        public Hasta Hasta { get; set; }

        public int DoktorID { get; set; }
        [ForeignKey("DoktorID")]
        public Doktor Doktor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Tarih{ get; set; }


        [Required(ErrorMessage = "Lütfen randevu saatini giriniz.")]
        public string RandevuSaati { get; set; }

    }
}
