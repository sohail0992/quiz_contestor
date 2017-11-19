using System;
using System.Net.Mail;

namespace midterm
{
    class Mail
    {
        public Boolean send(string email_to,string your_email_address,string pass,string subj,string body){
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email_to);
                mail.From = new MailAddress(your_email_address);
                mail.Subject = subj;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(your_email_address, pass);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }

        }
    }
}
