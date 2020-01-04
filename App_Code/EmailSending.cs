using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for EmailSending
/// </summary>
public class EmailSending
{
    public EmailSending()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    MailMessage mail;
    NetworkCredential mailAuthentication;
    static string FromID = "";                // ENTER FROM EMAIL ID
    static string pwd = "";                             // PASSWORD

    public void sendEMail(string ToEmail, string msg, string subject)
    {
        mail = new MailMessage(FromID, ToEmail, subject, msg);
        mailAuthentication = new NetworkCredential(FromID, pwd);
        SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
        mailClient.EnableSsl = true;
        mailClient.Credentials = mailAuthentication;
        mail.IsBodyHtml = true;
        mailClient.Send(mail);
    }
}