using Microsoft.EntityFrameworkCore;
using Randevu_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randevu_Sistemi.Data
{
    public class RandevuDbContext : DbContext
    {
        public RandevuDbContext(DbContextOptions<RandevuDbContext> options)
            : base(options)
        {

        }

        public DbSet<Hasta> Hastalar { get; set; }

        public DbSet<Doktor> Doktorlar { get; set; }

        public DbSet<Admin> Adminler{ get; set; }

        public DbSet<Randevu> Randevular { get; set; }
    }
}
