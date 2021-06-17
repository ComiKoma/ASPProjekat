using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.Email
{
    public class SendMailDto
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
