using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplication5.Pages {
    public static class Sender {
        public static void Email(String content) {
            try {
                Console.WriteLine("Sending...");
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("hectorsolar99@gmail.com");
                message.To.Add(new MailAddress("hectorsolar99@gmail.com"));
                message.Subject = "BirthdayInfo";
                //message.IsBodyHtml = true; //to make message body as html  
                message.Body = content;
                smtp.Port = 25;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                //ActualizarCredenciales para smtp
                smtp.Credentials = new NetworkCredential("hectorsolar99@gmail.com","");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                Console.WriteLine("Sended.");

            }
            catch( Exception e ) {
                Console.WriteLine(e);

            }
        }
    }
}
