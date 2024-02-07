using MedicalEquipmentCompany.Model.Result;
using Microsoft.IdentityModel.Tokens;

namespace MedicalEquipmentCompany.Model
{
    public class Company : Entity
    {
        public List<long> AdministratorIds { get; private set; }
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Description { get; private set; }
        public double AverageCompanyRating { get; private set; }
        //public List<long> EquipmentStock { get; private set; }
        public List<long> CompanyWorkingHours { get; private set; }

        public Company() { }

        public Company(List<long> administratorIds, string name, string street, string city, string country, string description, double averageCompanyRating, List<long> companyWorkingHours)
        {
            AdministratorIds = administratorIds;
            Name = name;
            Street = street;
            City = city;
            Country = country;
            Description = description;
            AverageCompanyRating = averageCompanyRating;
            //EquipmentStock = equipmentStock;
            CompanyWorkingHours = companyWorkingHours;
            Validate();
        }

        void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name.");
            if (string.IsNullOrWhiteSpace(Street)) throw new ArgumentException("Invalid Street.");
            if (string.IsNullOrWhiteSpace(City)) throw new ArgumentException("Invalid City.");
            if (string.IsNullOrWhiteSpace(Country)) throw new ArgumentException("Invalid Country.");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description.");
            if (AverageCompanyRating < 0) throw new ArgumentException("Invalid Avrage company rating.");
        }
    }
}
