using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace Approval_Api.Services
{
        public class MailService
        {
            public async Task smtpMailer(string toMailID, int status, int requestId,string Comments)
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
            string content;
            if (status == 1)
            {
                content = "Approval request for id : " + requestId;
            }
            else if(status == 2)
            {
                 content = "your request is approved with id : " + requestId;
            }
            else
            {
                 content = $"your requset {requestId} is  rejected due to {Comments}";
            }
                try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("satyajitdas159@gmail.com");
                    message.To.Add(toMailID);
                    message.Subject = subject;
                    message.IsBodyHtml = false; //to make message body as html
                    message.Body = content;
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = true;
                    smtp.Host = "smtp.gmail.com"; //for gmail host
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("satyajitdas159@gmail.com", "qqgdfdjtbkanumqn");
                  
                    smtp.Send(message);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }

