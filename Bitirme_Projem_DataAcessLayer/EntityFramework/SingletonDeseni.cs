using Bitirme_Projem_DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_DataAcessLayer.EntityFramework
{
   public class SingletonDeseni
    {
        protected static VeritabanıContext contex; //static değikenler static metotlara erişebilir
        private static object locky = new object();
        protected SingletonDeseni() //Clasın newlenmemesi için protected contructor kullanıldı
        {
             CreateContext();
        }   

        private static void CreateContext()
        {
            if (contex == null)
            {
                lock (locky) //Aynı anda iki thread çalıştırılamaz
                {
                        contex = new VeritabanıContext();
                    
                }
              
            }
            
        }
    }
}
