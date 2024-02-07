using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface IEmailService
    {
        public void SendVerificationEmail(string toEmail, int userId, string verificationToken);
        public void SendEmailWithAttachment(UserDto user, string subject, string body, byte[] attachmentBytes, string attachmentFileName);
    }
}
