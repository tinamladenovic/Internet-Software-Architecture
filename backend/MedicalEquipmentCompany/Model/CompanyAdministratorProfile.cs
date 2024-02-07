using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public class CompanyAdministratorProfile : Entity
    {
        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public long CompanyId { get; private set; }

        public CompanyAdministratorProfile() { }

        public CompanyAdministratorProfile(long userId, string name, string surname, string email, long companyId)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
            CompanyId = companyId;
        }
    }
}
