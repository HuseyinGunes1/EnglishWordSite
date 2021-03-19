using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
   public class MailHelper
    {
       
       public static void MailGönder(string GönderilecekKisi,string body,string baslık)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(GönderilecekKisi);//Kime gönderecez
            mail.From = new MailAddress("hssyyy.gnss@gmail.com");//Kimden gönderecez
            mail.Subject = baslık;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("hssyyy.gnss@gmail.com", "Mrlaamed.2112");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
               
            }
            catch (Exception ex)
            {
                new Exception();
            }


            

        }



    }
    }

