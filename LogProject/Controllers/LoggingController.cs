using LogProject.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogProject.Controllers
{
    public class LoggingController : Controller
    {
        // GET: Logging
        [HttpPost]
        public ActionResult Index(EmailMessage email) //NLOG
        {
            string key = ConfigurationManager.AppSettings["Sendgrid.Key"];
            SendGridService messageSvc = new SendGridService(key);

            string htmlBody = $@"<ul>From :{email.From}<li>To: {email.To}</li><li>Email: {email.Body}</li></ul>";

            EmailMessage msg = new EmailMessage()
            {
                Body = htmlBody,
                Subject = "Winifred Osezuah",
                From = email.From,
                To = email.To
            };

            string envPath = HttpRuntime.AppDomainAppPath;
            string fileName = $"{envPath}\\Log\\log-file.txt";
            byte[] fileData = null;
            FileInfo fileInfo = new FileInfo(fileName);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            fileData = br.ReadBytes((int)imageFileLength);

            messageSvc.SendMail(msg, true, fileName, fileData);
            return RedirectToAction("Success", "LogError");
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Log4Net(EmailMessage email)
        {
            string key = ConfigurationManager.AppSettings["Sendgrid.Key"];
            SendGridService messageSvc = new SendGridService(key);

            string htmlBody = $@"<ul>From :{email.From}<li>To: {email.To}</li><li>Email: {email.Body}</li></ul>";

            EmailMessage msg = new EmailMessage()
            {
                Body = htmlBody,
                Subject = "Winifred Osezuah",
                From = email.From,
                To = email.To
            };

            string envPath = HttpRuntime.AppDomainAppPath;
            string fileName = $"{envPath}\\Log\\log-file.txt";
            byte[] fileData = null;
            FileInfo fileInfo = new FileInfo(fileName);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            fileData = br.ReadBytes((int)imageFileLength);

            messageSvc.SendMail(msg, true, fileName, fileData);
            return RedirectToAction("Success", "LogError");
        }
        [HttpGet]
        public ActionResult Log4Net()
        {
            return View();
        }
    }
}