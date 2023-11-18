using System.Net.Mail;

namespace Notification.Target.Email
{
    public class EmailSender
    {
        private static readonly string EMAIL_SUBJECT = "Daily Error Report";

        public async void SendEmails(List<string> toEmails, string htmlContent) =>
            await CreateSMTPClientInstance().SendMailAsync(CreateMailMessage(toEmails, htmlContent));

        private MailMessage CreateMailMessage(List<string> toEmails, string htmlContent)
        {
            MailMessage message = new MailMessage();
            message.Subject = EMAIL_SUBJECT;

            foreach (string email in toEmails)
            {
                message.To.Add(email);
            }

            message.IsBodyHtml = true;
            message.Body = htmlContent;

            return message;
        }

        private SmtpClient CreateSMTPClientInstance() =>
            new SmtpClient();
    }
}
