﻿using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System;
using Approval_Api.DataModel_.entities;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Approval_Api.helpers
{
    public class EmailServices
    {

        public static void smtpMailer(int status, string toMailid, string fromMailId)
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
            //string content;
            //if (status == 1)
            //{
            //    content = "Approval request for id : " + requestId;
            //}
            //else if (status == 2)
            //{
            //    content = "your request is approved with id : " + requestId;
            //}
            //else
            //{
            //    content = $"your requset {requestId} is  rejected due to {Comments}";
            //}
            try
            {
                MailMessage message = new MailMessage(toMailid, fromMailId);
                SmtpClient smtp = new SmtpClient();
                
                message.Subject = subject;
                message.IsBodyHtml = false; //to make message body as html
                message.Body = "Congratulation u won 5000 INR";
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
        //public static string EmailNotification(string fromAddress, string toAddress)
        //{
        //    MailMessage message = new MailMessage(fromAddress, toAddress);
        //    message.Subject = "New request from employee";
        //    message.Body = "You have request for approval";

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.EnableSsl = true;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        //    System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
        //    credential.UserName = "satyajitdas159@gmail.com";
        //    credential.Password = "Chintu@99";
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = credential;

        //    smtp.Send(message);

        //    return "Success";
        //}
    }
    }

