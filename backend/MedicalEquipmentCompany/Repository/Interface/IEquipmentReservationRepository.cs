using MedicalEquipmentCompany.Model;

namespace MedicalEquipmentCompany.Repository.Interface
{
    public interface IEquipmentReservationRepository 
    {
        public List<EquipmentReservation> SearchByUserId(int userId);
    }
}
