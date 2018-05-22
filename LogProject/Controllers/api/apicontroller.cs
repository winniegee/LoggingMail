using LogProject;
using LogProject.Messaging;
using LogProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LogProject.Controllers.api
{
    [RoutePrefix("api/settingsapi")]
    public class SettingsApiController : ApiController
    {
        //private UserManager<AppUser, Guid> userMgr;
        //private RoleManager<AppRole, Guid> roleMgr;
        //public SettingsApiController()
        //{
        //    userMgr = Startup.UserManagerFactory.Invoke();
        //    roleMgr = Startup.RoleManagerFactory.Invoke();
        //}

        [Route("Email")]
        [HttpPost]

        public HttpResponseMessage SendEmail(EmailModel email)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "your fields are not valid");
                }

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

                return this.Request.CreateResponse(HttpStatusCode.OK, "Successfully sent mail");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
}