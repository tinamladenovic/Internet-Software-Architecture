using System.Globalization;
using System.Net.Mail;
using MedicalEquipmentCompany.Model.Result;


namespace MedicalEquipmentCompany.Model
{
    public class Account : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Phone { get; private set; }
        public string Profession { get; private set; }
        public long UserId { get; private set; }
        public bool IsActivate { get; private set; }
        public string Enterprise { get; private set; } 
        public int Penalties { get; private set; }

        public Account() { }
        public Account(string name, string surname, string email, string city, string country, string phone, string profession, string enterprise, long userId, bool isActivate, int penalties)
        {
            Name = name;
            Surname = surname;
            Email = email;
            City = city;
            Country = country;
            Phone = phone;
            Profession = profession;
            Enterprise = enterprise;
            Penalties = penalties;
            UserId = userId;
            IsActivate = isActivate;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name.");
            if (string.IsNullOrWhiteSpace(Surname)) throw new ArgumentException("Invalid Surname.");
            if (string.IsNullOrWhiteSpace(City)) throw new ArgumentException("Invalid City.");
            if (string.IsNullOrWhiteSpace(Country)) throw new ArgumentException("Invalid Country.");
            if (string.IsNullOrWhiteSpace(Phone)) throw new ArgumentException("Invalid Phone number.");
            if (string.IsNullOrWhiteSpace(Profession)) throw new ArgumentException("Invalid Profession.");
            if (!MailAddress.TryCreate(Email, out _)) throw new ArgumentException("Invalid Email adress.");
            if (string.IsNullOrWhiteSpace(Enterprise)) throw new ArgumentException("Invalid Enterprise informations.");
            if (Penalties < 0) throw new ArgumentException("Invalid Penalites.");

        }
    }
}