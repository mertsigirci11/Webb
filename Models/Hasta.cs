using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Randevu_Sistemi.Models
{
    public class Hasta
    {
        [Required(ErrorMessage ="Lütfen TC no giriniz.")]
        [Key]
        public string HastaTCNo{ get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string HastaAd { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string HastaSoyad { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        public string HastaSifre{ get; set; }


    }
}
