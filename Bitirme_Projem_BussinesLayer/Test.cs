using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitirme_Projem_DataAcessLayer.EntityFramework;
namespace Bitirme_Projem_BussinesLayer
{
   public class Test
    {
        public Test()
        {
            VeritabanıContext db = new VeritabanıContext();
            db.Database.CreateIfNotExists();
        }
    }
}
