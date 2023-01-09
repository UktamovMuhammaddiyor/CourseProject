using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CourseProject.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var GridKey = "";
            await Execute(GridKey, subject, message, toEmail);
        }

        private async Task Execute(string gridKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(gridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("uktamov.info@gmail.com", "Muhammaddiyor"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
