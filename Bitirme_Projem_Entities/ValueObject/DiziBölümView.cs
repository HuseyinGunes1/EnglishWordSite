using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace Bitirme_Projem_Entities.ValueObject
{
   public class DiziBölümView
    {
        public DiziBölümView()
        {
            this.My_Sezon = new List<SelectListItem>();
            My_Sezon.Add(new SelectListItem { Text = "Seçiniz", Value = " " });
            this.My_Bölüm = new List<SelectListItem>();
            My_Bölüm.Add(new SelectListItem { Text = "Seçiniz", Value = " " });
        }

        public int DiziId { get; set; }
        public int SezonId { get; set; }
        public int BölümId { get; set; }

        public List<SelectListItem> My_Diziler { get; set; }
        public List<SelectListItem> My_Sezon { get; set; }
        public List<SelectListItem> My_Bölüm { get; set; }
    }
}
