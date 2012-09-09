using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Sirius.Net.Mail
{
    public class DevPublicSmtpClient
    {
        private SmtpClient _gmailSmtpClient;

        public DevPublicSmtpClient()
        {
            _gmailSmtpClient = new SmtpClient();
            _gmailSmtpClient.Host = "smtp.gmail.com";
            _gmailSmtpClient.Port = 587;
            _gmailSmtpClient.EnableSsl = true;
            _gmailSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _gmailSmtpClient.UseDefaultCredentials = false;
            _gmailSmtpClient.Credentials = new NetworkCredential("dev@kunzhu.co.cc", "dev.public");
        }

        public void Send(MailMessage mailMessage)
        {
            mailMessage = WrapMailMessage(mailMessage);
            _gmailSmtpClient.Send(mailMessage);
        }

        private MailMessage WrapMailMessage(MailMessage mailMessage)
        {
            StringWriter msgsignatureWriter = new StringWriter();
            msgsignatureWriter.WriteLine();
            msgsignatureWriter.WriteLine("--------------------------------");
            msgsignatureWriter.WriteLine("I'm glad that my service can help you.");
            msgsignatureWriter.WriteLine("If there's any question feel free to send me email: ariesyzhk@gmail.com");
            msgsignatureWriter.WriteLine("More interesting things can be found at my technique blog: http://kunzhu.co.cc");
            msgsignatureWriter.WriteLine("and my code repository: https://github.com/ariesy");

            mailMessage.Body += msgsignatureWriter.ToString();
            mailMessage.ReplyToList.Add(new MailAddress("ariesyzhk@gmail.com", "Kun Zhu"));
            return mailMessage;
        }
    }
}
