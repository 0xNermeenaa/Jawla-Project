using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class EmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUser = "jawla1000@gmail.com";
        private readonly string _smtpPass = "veyx wwsm zlzn ltcm"; // استخدم App Password

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            if (!IsValidEmail(toEmail))
            {
                Console.WriteLine($"❌ البريد الإلكتروني غير صالح: {toEmail}");
                return false;
            }

            try
            {
                using (var client = new SmtpClient(_smtpServer, _smtpPort))
                {
                    client.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_smtpUser),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true,
                    };

                    mailMessage.To.Add(toEmail);

                    await client.SendMailAsync(mailMessage);
                    Console.WriteLine($"✅ تم إرسال البريد الإلكتروني بنجاح إلى {toEmail}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ خطأ أثناء إرسال البريد الإلكتروني: {ex.Message}");
                return false;
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
