  using Bitirme_Projem_DataAcessLayer;
using Bitirme_Projem_DataAcessLayer.Abstract;
using Bitirme_Projem_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Bitirme_Projem_DataAcessLayer.EntityFramework
{
   public class RepositoryDeseni<Tablo>:SingletonDeseni, IRepository<Tablo> where Tablo:class //Tablomuz class olması lazım oraya int vb değerler gelmemeli
    {
        
       
        private DbSet<Tablo> dbnesne;

        //Yapıcı Metot
        public RepositoryDeseni()
        {
            dbnesne =contex.Set<Tablo>();//Her seferinde Set etmemek için
        }


        
        //İlgili Metotlar
        public List<Tablo> Listele()
        {
           return dbnesne.ToList();   //LİSTELE
        }

       
        public int Kaydet()
        {
            return contex.SaveChanges(); //VERİTABANINA KAYDET
            
        }

       
        public int Ekle(Tablo nesne)
        {
            dbnesne.Add(nesne);  //VERİTABANINA EKLE
            return Kaydet(); 
        }
        public int Güncelle(Tablo nesne)
        {
            return Kaydet();
        }
        public int Sil(Tablo nesne)
        {
            dbnesne.Remove(nesne);
            return Kaydet();
        }
    }
}
