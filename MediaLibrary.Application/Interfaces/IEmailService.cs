using MediaLibrary.Domain.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(MailRequest request);
}
