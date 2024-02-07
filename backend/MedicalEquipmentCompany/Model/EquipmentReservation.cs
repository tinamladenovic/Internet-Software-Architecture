using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public enum Status
    {
        OnWait,
        Completed,
        Expired,
        Canceled
    }
    public class EquipmentReservation : Entity
    {
        public long UserId { get; private set; }
        public long CompanyId { get; private set; }
        public DateTime ReservationDate { get; private set; }
        public Status ReservationStatus { get; private set; }
        public List<long> ReservedEquipment { get; private set; }
        public List<int> EquipmentCount { get; private set; }
        public long EquipmentPickup { get; private set; }

        public EquipmentReservation() { }

        public EquipmentReservation( long userId, long comapnyId, DateTime reservationDate, Status reservationStatus, List<long> reservedEquipment, List<int> equipmentCount, long equipmentPickup)
        {
            UserId = userId;
            CompanyId = comapnyId;
            ReservationDate = reservationDate;
            ReservationStatus = reservationStatus;
            ReservedEquipment = reservedEquipment;
            EquipmentCount = equipmentCount;
            EquipmentPickup = equipmentPickup;
        }
    }
}
