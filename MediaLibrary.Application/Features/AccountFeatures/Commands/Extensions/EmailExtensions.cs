using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Mail;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.AccountFeatures.Commands.Extensions;

public static class EmailExtensions
{
    internal static async Task SendEmail_VerificationURL(this IEmailService emailService, string email, string verificationUrl)
    {
        await emailService.SendEmailAsync(new()
        {
            ToEmail = email,
            Subject = "Confirm your Email",
            Body = $"Please confirm your account by visiting this URL {verificationUrl}",
        });
    }
    internal static async Task SendEmail_PasswordReseted(this IEmailService emailService, string email)
    {
        await emailService.SendEmailAsync(new()
        {
            Body = $"The password has been reseted",
            ToEmail = email,
            Subject = "Password Changed",
        });
    }
    internal static async Task SendEmail_PasswordChanged(this IEmailService emailService, string email)
    {
        await emailService.SendEmailAsync(new()
        {
            Body = $"The password has been changed",
            ToEmail = email,
            Subject = "Password Changed",
        });
    }
}
