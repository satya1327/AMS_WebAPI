using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System;
using Approval_Api.DataModel_.entities;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Approval_Api.helpers
{
    public class EmailServices
    {

        public static void smtpMailer(int status, string toMailid, string fromMailId,string comments)
        {

            var subject = "";
            if (status == 1)
            {
                subject = "A request is been raised to you.";
            }
            else if (status == 2)
            {

                subject = "Your Request is Approved";
            }
            else if (status == 3)
            {
                subject = "Your Request is Rejected";
            }
            else if (status == 2002)
            {
                subject = "Your Request is forwarded";
            }
            string content;
            if (status == 1)
            {
                content = "Approval request  :  ";
            }
            else if (status == 2)
            {
                content = "your request is approved  ";
            }
            else if(status == 2002)
            {
                content = $"your requset  is  forwarded";
            }
            else
            {
                
                content = $"your requset  is  rejected due to {comments}";
            
            }
            try
            {
                MailMessage message = new MailMessage(toMailid, fromMailId);
                SmtpClient smtp = new SmtpClient();
                
                message.Subject = subject;
                message.IsBodyHtml = false; //to make message body as html
                message.Body = content;
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("satyajitdas159@gmail.com", "qqgdfdjtbkanumqn");
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {

            }
        }
       
    }
    }


