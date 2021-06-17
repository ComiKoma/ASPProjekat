using ASPProjekat.Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ASPProjekat.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(SendMailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("example@example.com", "password")
            };

            var message = new MailMessage("example@example.com", dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            //smtp.Send(message);
        }
    }
}
