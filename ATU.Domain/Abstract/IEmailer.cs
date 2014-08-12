using System;
using System.Collections.Generic;

namespace ATU.Domain.Abstract
{
    public interface IEmailer
    {
        void SendEmail(string from, string to, string subject, string html, string text);
        void SendEmail(string from, List<String> to, string subject, string html, string text);
    }
}