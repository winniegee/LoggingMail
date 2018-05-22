using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LogProject.Messaging
{
    public class SendGridService
    {
        private readonly SendGridMessage msg;
        private readonly SendGridClient client;
        public SendGridService(string apiKey, string senderEmail="winnie@cyberacademy.com", string senderName="Winifred Osezuah")
        {
            msg = new SendGridMessage();
            msg.From = new EmailAddress(senderEmail, senderName);
            client = new SendGridClient(apiKey);
        }
        //public async Task<string> SendMail(EmailMessage message, Boolean isHtml)
        //{
        //    msg.AddTo(message.To);
        //    msg.Subject = message.Subject;
        //    if (isHtml)
        //        msg.HtmlContent = message.Body;
        //    msg.PlainTextContent = message.Body;
            
        //    SendGrid.Response response = await client.SendEmailAsync(msg);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        return "Message sent successfully";
        //    return string.Empty;
       // }
        public void SendMail(EmailMessage message, Boolean isHtml, string fileName, Byte[] fileBytes)
        {
            msg.AddTo(message.To);
            msg.Subject = message.Subject;

            if (!isHtml)
            {
                msg.PlainTextContent = message.Body;
            }
            else
            {
                msg.HtmlContent = message.Body;
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                string fileContents = Convert.ToBase64String(fileBytes);
                msg.AddAttachment(fileName, fileContents);
            }

            client.SendEmailAsync(msg);
        }
    }
}
