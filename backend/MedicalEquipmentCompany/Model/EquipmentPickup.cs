using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public class EquipmentPickup : Entity
    {
        public long AdministratorId { get; private set; }
        public long CompanyId { get; private set; }
        public DateTime DateAndTime { get; private set; }
        public int Duration { get; private set; }
        public bool IsReserved { get; private set; }


        public EquipmentPickup () { }

        public EquipmentPickup( long administratorId, long companyId, DateTime dateAndTime, int duration, bool isReserved)
        {
            AdministratorId = administratorId;
            CompanyId = companyId;
            DateAndTime = dateAndTime;
            Duration = duration;
            IsReserved = isReserved;
        }
    }
}
