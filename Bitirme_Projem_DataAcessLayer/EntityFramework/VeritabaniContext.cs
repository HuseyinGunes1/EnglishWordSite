using Bitirme_Projem_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_DataAcessLayer.EntityFramework
{
    public class VeritabanıContext : DbContext    
    {  
        public DbSet<Diziler> Diziler { get; set; }  
        public DbSet<Kategoriler> Kategoriler { get; set; }
        public DbSet<Kelime_Dizi> Kelime_Dizi { get; set; }
        public DbSet<Kelimeler> Kelimeler { get; set; }
        public DbSet<Sezon> DiziSezon { get; set; }
        public DbSet<Bölüm> DiziBölüm { get; set; }
        public DbSet<Kullanıcı_Kelime> KullanıcıKelime { get; set; }
        public DbSet<Uyeler> Uyeler { get; set; }
        
    }

   
}
