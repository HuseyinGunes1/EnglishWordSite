using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Common.Helpers;
using Bitirme_Projem_Entities;
using Bitirme_Projem_DataAcessLayer.EntityFramework;

namespace Bitirme_Projem_BussinesLayer
{
    public class QuartzJob : IJob
    {
        RepositoryDeseni<Uyeler> Kisiler = new RepositoryDeseni<Uyeler>();
        public void Execute(IJobExecutionContext context)
        {
            MailBody m = new MailBody();
          List<Uyeler> uye = Kisiler.Listele().ToList();
            foreach(var x in uye)
            {
                MailHelper.MailGönder(x.Kullanici_EPosta,m.Body(x.Kullanicı_Id,3),x.Kullanici_Ad+" "+" Öğrenceğin Kelimeleri Tekrar Et");
            }
            
        }
    }
}
