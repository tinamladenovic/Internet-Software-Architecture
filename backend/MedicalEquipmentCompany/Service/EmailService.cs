using System.Net.Mail;
using System.Net;
using MedicalEquipmentCompany.Service.Interface;
using MedicalEquipmentCompany.Model.Dtos;
using QRCoder;
using MedicalEquipmentCompany.Model;

namespace MedicalEquipmentCompany.Service
{
    public class EmailService : IEmailService
    {
        public void SendVerificationEmail(string toEmail, int userId, string verificationToken)
        {
            // Update the base URL to match your actual website URL
            string baseUrl = "https://localhost:44333/api/users";

            // Generate the verification link with userId and token parameters
            string verificationLink = $"{baseUrl}/verifyemail?userId={userId}&token={verificationToken}";

            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("medicalequipmentcompany0@gmail.com", "vjak vowh zbpg yexe");
                client.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("medicalequipmentcompany0@gmail.com", "Medical Equipment Company");
                message.To.Add(toEmail);
                message.Subject = "Medical Equipment Company profile verification.";
                message.Body = $"Click the link to verify your email: <a href='{verificationLink}'>Verify</a>";
                message.IsBodyHtml = true;

                client.Send(message);
            }
        }

        public void SendEmailWithAttachment(UserDto user, string subject, string body, byte[] attachmentBytes, string attachmentFileName)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("medicalequipmentcompany0@gmail.com", "vjak vowh zbpg yexe");
                client.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("medicalequipmentcompany0@gmail.com", "Medical Equipment Company");

                // Change the recipient email to the user's email
                message.To.Add(user.Email);

                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                // Attach QR code
                using (MemoryStream qrStream = new MemoryStream(attachmentBytes))
                {
                    Attachment qrAttachment = new Attachment(qrStream, attachmentFileName, "image/png");
                    message.Attachments.Add(qrAttachment);

                    client.Send(message);
                }
            }
        }


    }
}
