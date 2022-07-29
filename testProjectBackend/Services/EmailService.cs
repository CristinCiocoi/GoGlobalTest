using System;
using System.Net;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace testProjectBackend.Services
{
    public class EmailService : IEmailService
    {
        private MailMessage Message { get; set; }
        private readonly SmtpClient _client;
        
        public EmailService()
        {
            _client = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                    "cristintest@outlook.com",
                    "Test123!Test123!")
            };
        }
        
        public async Task<bool> SendEmailAsync(string @from, string to, string subject, string html)
        {
            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                var mailAddress = new MailAddress(@from);
                Message = new MailMessage { From = mailAddress};
                Message.To.Add(new MailAddress(to));
                Message.IsBodyHtml = true;
                Message.Subject = subject;
                Message.Body = html;
                _client.DeliveryMethod = SmtpDeliveryMethod.Network;
                await _client.SendMailAsync(Message);

                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
                return false; 
            }
        }
    }
}