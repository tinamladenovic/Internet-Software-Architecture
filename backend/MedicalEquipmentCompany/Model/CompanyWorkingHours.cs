using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public class CompanyWorkingHours : Entity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public CompanyWorkingHours() { }

        public CompanyWorkingHours( DayOfWeek dayOfWeek, DateTime startTime, DateTime endTime)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
