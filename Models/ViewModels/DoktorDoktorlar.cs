using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randevu_Sistemi.Models.ViewModels
{
    public class DoktorDoktorlar
    {
        public Doktor Doktor { get; set; }
        public IEnumerable<Doktor> Doktorlar { get; set; }
    }
}
