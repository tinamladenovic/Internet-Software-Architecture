using MedicalEquipmentCompany.Model.Result;
using System.Net.Mail;

namespace MedicalEquipmentCompany.Model
{
    public class Person : Entity
    {
        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }

        public Person(long userId, string name, string surname, string email)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
        }

        private void Validate()
        {
            if (UserId == 0) throw new ArgumentException("Invalid UserId");
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Surname)) throw new ArgumentException("Invalid Surname");
            if (!MailAddress.TryCreate(Email, out _)) throw new ArgumentException("Invalid Email");
        }
    }
}
