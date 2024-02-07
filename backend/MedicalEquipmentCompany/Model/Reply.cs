using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public class Reply : Entity
    {
        public long UserId { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Reply() { }

        public Reply( long userId, string text, DateTime createdAt)
        {
            UserId = userId;
            Text = text;
            CreatedAt = createdAt;
        }
    }
}
