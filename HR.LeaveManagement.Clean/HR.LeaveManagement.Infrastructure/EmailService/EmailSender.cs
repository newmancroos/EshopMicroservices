using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR.LeaveManagement.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    public EmailSettings _emailSetting { get; }
    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSetting = emailSettings.Value;
    }
    public async Task<bool> SendEmail(EmailMessage email)
    {
        var client = new SendGridClient(_emailSetting.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress
        {
            Email = _emailSetting.FromAddress,
            Name = _emailSetting.FromName
        };

        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(message);

        //return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;

        return response.IsSuccessStatusCode;
    }
}
