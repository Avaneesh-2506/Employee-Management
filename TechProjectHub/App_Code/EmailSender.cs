using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace TechProjectHub.App_Code
{
    public class EmailSender
    {
        string MyEmailId, MyEmailPassCode;

        public EmailSender()
        {
            MyEmailId = "009avaneesh@gmail.com";
            MyEmailPassCode = "enatcpwjeqvcqmjt";
        }

        internal bool SendMyEmail(string SendTo, string Subject, string Message)
        {

            try
            {
                //Setting Protocol
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential(MyEmailId, MyEmailPassCode);
                smtp.Credentials = nc;
                smtp.EnableSsl = true;
                //Setting MailMessage
                MailMessage msg = new MailMessage();
                MailAddress maFrom = new MailAddress(MyEmailId);
                MailAddress maTo = new MailAddress(SendTo);
                msg.Sender = maFrom;
                msg.To.Add(maTo);
                msg.Subject = Subject;
                msg.From = maFrom;
                msg.Body = Message;
                smtp.Send(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}