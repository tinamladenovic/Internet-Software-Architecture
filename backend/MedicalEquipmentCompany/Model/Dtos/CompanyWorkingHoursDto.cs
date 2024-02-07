namespace MedicalEquipmentCompany.Model.Dtos
{
    public class CompanyWorkingHoursDto
    {
        public long Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
