using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TestEmail2
{
    public class Sendmail
    {
        public static void Email(string to, string subject, string body)
        {
            MailMessage mm = new();
            mm.To.Add(new MailAddress(to));
            mm.From = new MailAddress("tech-admin@devblock.net");
            mm.Subject = subject;
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            SmtpClient smtpClient = new();
            smtpClient.Host = "smtp.office365.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("tech-admin@devblock.net", "MadLife123@");
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtpClient.Send(mm);
        }
    }
}
