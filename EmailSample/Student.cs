using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace EmailSample
{
    class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Mailid { get; set; }
        public string Message { get; set; }
       

        public bool Mail(string mailad, string Message, string name, int rollno)
        {
            
            var fromAddress = new MailAddress("rahamath22104@gmail.com", "Rahamath");
            var toAddress = new MailAddress(mailad, name);
            
            const string fromPassword = "qzyk ddtt mpjz qefw";
            const string subject = " Message";
            string body = Message;
            

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
                try
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("D:\\Jaffersha\\" + rollno + ".txt");
                    message.Attachments.Add(attachment);
                }
                catch(Exception ex){}
                try
                {
                    smtp.Send(message);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    
                }
            }

        }

       
    }
}
