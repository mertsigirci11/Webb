using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Randevu_Sistemi.Models
{
    public class Admin
    {
        [Key]
        [Required(ErrorMessage ="Lütfen Admin adını giriniz.")]
        public string AdminAd{ get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Lütfen admin şifresini giriniz.")]
        public string AdminSifre { get; set; }
    }
}
