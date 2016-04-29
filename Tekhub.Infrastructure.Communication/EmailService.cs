using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Tekhub.Framework;

namespace Tekhub.Infrastructure.Communication
{
    public class EmailService: IEmailService
    {
        public void SendEmail(MailMessage message, SmtpSection smtpSection)
        {
            using (SmtpClient smtpClient = new SmtpClient(smtpSection.Network.Host, smtpSection.Network.Port))
            {
                message.From = new MailAddress(smtpSection.From);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                smtpClient.Credentials = credentials;
                smtpClient.Send(message);

            }
        }
    }
}
