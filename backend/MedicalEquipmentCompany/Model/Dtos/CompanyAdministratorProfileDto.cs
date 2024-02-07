using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalEquipmentCompany.Model.Dtos
{
    public class CompanyAdministratorProfileDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long CompanyId { get; set; }
    }
}
