using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace EmailSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var fromAddress = new MailAddress("rahamath22104@gmail.com", "Rahamath");
            var toAddress = new MailAddress("jaffersha786@gmail.com", "Jaffer");
            const string fromPassword = "qzyk ddtt mpjz qefw";
            const string subject = "This mail is form rahamath";
            const string body = "Hello Daddy";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
    
   
    

       }
    }
}
