namespace MedicalEquipmentCompany.Model.Dtos
{
    public class ComplainDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }
        public ComplaintType Type { get; set; }
        public bool IsResolved { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? Reply { get; set; }
    }

}