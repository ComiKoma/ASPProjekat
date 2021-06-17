using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.Email
{
    public interface IEmailSender
    {
        void Send(SendMailDto dto);
    }
}
