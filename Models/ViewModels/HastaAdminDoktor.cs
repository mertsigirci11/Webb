using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randevu_Sistemi.Models.ViewModels
{
    public class HastaAdminDoktor
    {
        public Hasta hasta { get; set; }
        public Doktor doktor { get; set; }
        public Admin admin { get; set; }
        public Randevu randevu { get; set; }
    }
}
