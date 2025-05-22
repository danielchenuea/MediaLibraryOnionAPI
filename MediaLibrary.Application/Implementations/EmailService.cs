using AutoMapper.Internal;
using MailKit.Net.Smtp;
using MailKit.Security;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Mail;
using MediaLibrary.Domain.Settings;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Implementations;

public class EmailService : IEmailService
{
    private readonly MailSettings _mailSettings;
    public EmailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(MailRequest request)
    {
        using var smtp = new SmtpClient();
        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        
        await smtp.SendAsync(BuildEmail(request));

        smtp.Disconnect(true);
    }

    private MimeMessage BuildEmail(MailRequest request)
    {
        var email = new MimeMessage();

        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(request.ToEmail));
        email.Subject = request.Subject;

        var builder = new BodyBuilder();
        if (request.Attachments != null)
        {
            byte[] fileBytes;
            foreach (var file in request.Attachments)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }
        }
        builder.HtmlBody = request.Body;
        email.Body = builder.ToMessageBody();
        
        return email;
    }
}
