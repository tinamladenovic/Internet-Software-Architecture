using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model;

namespace MedicalEquipmentCompany.Repository.Interface
{
    public interface IEquipmentPickupRepository
    {
        public List<EquipmentPickup> SearchByCompany(int companyId);
    }
}
