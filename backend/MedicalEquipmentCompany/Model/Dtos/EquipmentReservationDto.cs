namespace MedicalEquipmentCompany.Model.Dtos
{
    public class EquipmentReservationDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public DateTime ReservationDate { get; set; }
        public Status ReservationStatus { get; set; }
        public List<long> ReservedEquipment { get; set; }
        public List<int> EquipmentCount { get; set; }
        public long EquipmentPickup { get; set; }

    }
}
