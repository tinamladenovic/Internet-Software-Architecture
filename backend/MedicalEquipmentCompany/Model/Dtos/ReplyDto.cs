namespace MedicalEquipmentCompany.Model.Dtos
{
    public class ReplyDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
