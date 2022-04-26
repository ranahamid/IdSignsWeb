using Microsoft.AspNet.Identity;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var mailUser = "YOUR_MAIL_USER";
            MailMessage mail = new MailMessage();
            try
            {
                mail.To.Add(message.Destination);
                mail.From = new MailAddress(mailUser, "Eatsy");
                mail.Subject = message.Subject;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;
                mail.Body = message.Body;

                SmtpClient client = new SmtpClient
                {
                    EnableSsl = true
                };
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception)
            {
                mail.Dispose();
                throw;
            }
            return Task.FromResult(0);
        }
    }
}
