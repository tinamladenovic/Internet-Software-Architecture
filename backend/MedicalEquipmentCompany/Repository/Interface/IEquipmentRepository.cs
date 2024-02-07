using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model;

namespace MedicalEquipmentCompany.Repository.Interface
{
    public interface IEquipmentRepository
    {
        public List<Equipment> Search(EquipmentSearchDto companySearch);
        public List<Equipment> SearchByCompany(int companyId);
    }
}
