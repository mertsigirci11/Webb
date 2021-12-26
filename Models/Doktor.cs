using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Randevu_Sistemi.Models
{
    public class Doktor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage="Lütfen doktor id giriniz.")]
        [Key, Column(Order = 0)]
        public int DoktorID { get; set; }

        [Required(ErrorMessage ="Lütfen doktor adını giriniz.")]
        public string DoktorAd { get; set; }

        [Required(ErrorMessage = "Lütfen doktor soyadını giriniz.")]
        public string DoktorSoyad { get; set; }


        [Required(ErrorMessage = "Lütfen doktor şifresini giriniz.")]
        [DataType(DataType.Password)]
        public string DoktorSifre { get; set; }

        public bool Aktiflik { get; set; }
    }
}
