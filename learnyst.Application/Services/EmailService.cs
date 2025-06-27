using learnyst.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace learnyst.Application.Services
{
    //TODO:
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendAsync(string toEmail, string subject, string htmlBody)
        {
            var apiKey = _config["SendGrid:ApiKey"];
            var senderEmail = _config["SendGrid:FromEmail"];
            var senderName = _config["SendGrid:FromName"];

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(senderEmail, senderName);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent: null, htmlContent: htmlBody);

            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Body.ReadAsStringAsync();
                throw new Exception($"SendGrid Error: {response.StatusCode}\n{error}");
            }
        }

        //private readonly IConfiguration _config;

        //public EmailService(IConfiguration config)
        //{
        //    _config = config;
        //}

        //public async Task SendAsync(string toEmail, string subject, string body)
        //{
        //    var smtpSettings = _config.GetSection("SmtpSettings");

        //    var message = new MailMessage
        //    {
        //        From = new MailAddress(smtpSettings["SenderEmail"]),
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = true
        //    };

        //    message.To.Add(new MailAddress(toEmail));

        //    using var smtp = new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"]))
        //    {
        //        Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
        //        EnableSsl = true, // This enables TLS
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false
        //    };

        //    await smtp.SendMailAsync(message);
        //}
    }
}
