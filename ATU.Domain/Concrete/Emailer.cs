using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using ATU.Domain.Abstract;
using SendGridMail;

namespace ATU.Domain.Concrete
{
    public class Emailer : IEmailer
    {
        private readonly IConfigurationService _configurationService;

        public Emailer(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public void SendEmail(string from, List<String> to, string subject, string html, string text)
        {
            //if (!_configurationService.SendGridActive) return;

            //var myMessage = SendGrid.GetInstance();
            //var credentials = new NetworkCredential(_configurationService.SendGridUsername, _configurationService.SendGridPassword);
            //var transportSMTP = Web.GetInstance(credentials);

            //myMessage.From = new MailAddress(from);
            //myMessage.AddTo(to);
            //myMessage.Subject = subject;
            //myMessage.Html = html;
            //myMessage.Text = text;

            //transportSMTP.Deliver(myMessage);
        }

        public void SendEmail(string from, string to, string subject, string html, string text)
        {
            // Add multiple addresses to the To field.
            var recipients = new List<String> { to };

            SendEmail(from, recipients, subject, html, text);
        }
    }
}
