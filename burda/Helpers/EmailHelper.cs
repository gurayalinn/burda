using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burda.Helpers
{
    internal class EmailHelper
    {
        public bool SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(burda.Properties.Settings.Default.SMTP_MAIL, burda.Properties.Settings.Default.SMTP_PASSWORD)
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(burda.Properties.Settings.Default.SMTP_MAIL, "Burda"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                smtpClient.Send(mailMessage);
                Logger.Information($"Mail gönderildi: {toEmail} - {subject}");

                return true;
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"SMTP Hatası: {smtpEx.Message}");
                if (smtpEx.InnerException != null)
                {
                    Console.WriteLine($"Detay: {smtpEx.InnerException.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Genel Hata: {ex.Message}");
            }

            return false;
        }
    }
}
