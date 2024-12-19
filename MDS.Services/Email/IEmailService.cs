using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Email
{
    public interface IEmailService : IService
    {
        Task SendAsync(string subject, string body, string from, string to);
        Task<bool> Send(MailMessage message, IEnumerable<Attachment> attachments = null, List<string> bcc = null);

        Task SendEmailConfirmationAsync(string email, string callbackUrl);

        Task SendPasswordResetAsync(string email, string callbackUrl);

        Task SendException(Exception ex, string subject = null);
    }
}
