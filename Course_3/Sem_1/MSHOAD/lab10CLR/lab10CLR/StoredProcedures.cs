using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net.Mail;
using System.Net;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SendEmailOnDelete(SqlString customerName, Route route)
    {
        // Your email settings
        string smtpServer = "smtp.gmail.com";
        string smtpUsername = "pashok12.obodov@gmail.com";
        string smtpPassword = "mlkwcnikhiuuijrz";
        int smtpPort = 587;

        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress("pashok12.obodov@gmail.com");
            mail.To.Add("pashok12.obodov@gmail.com");
            mail.Subject = "Data Deleted in Customers Table";
            mail.Body = $"Customer {customerName} data was deleted. Route: {route}";

            using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
            {
                smtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
    }
}