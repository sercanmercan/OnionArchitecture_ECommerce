using ETicaretAPI.Application.Abstractions.AppServices.MailServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.AppServices.MailServices
{
    public class MailService : IMailService
    {
        public async Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMessageAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            try
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ETicaret.API"));
                configurationManager.AddJsonFile("appsettings.json");
                var host = configurationManager.GetSection("Smtp")["Host"];
                var port = configurationManager.GetSection("Smtp")["Port"];
                var username = configurationManager.GetSection("Smtp")["Username"];
                var password = configurationManager.GetSection("Smtp")["Password"];

                MailMessage mail = new();
                mail.IsBodyHtml = isBodyHtml;
                foreach (var to in tos)
                    mail.To.Add(to);

                mail.Subject = subject;
                mail.Body = body;
                mail.From = new(username);

                SmtpClient smtp = new SmtpClient(host)
                {
                    Port = int.Parse(port),
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = true
                };

                Random random = new();
                int randomInRange = random.Next(10000, 30000);
                await Task.Delay(randomInRange);
                await smtp.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
