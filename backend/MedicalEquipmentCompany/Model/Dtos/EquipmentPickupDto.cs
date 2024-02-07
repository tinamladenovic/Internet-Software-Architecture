namespace MedicalEquipmentCompany.Model.Dtos
{
    public class EquipmentPickupDto
    {
        public long Id { get; set; }
        public long AdministratorId { get; set; }
        public long CompanyId { get; set; }
        public string DateAndTime { get; set; }
        public int Duration { get; set; }
        public bool IsReserved { get; set; }


    }
}
