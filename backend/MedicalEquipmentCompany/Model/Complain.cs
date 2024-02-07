using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public class Complain : Entity
    {
        public long UserId { get; set; }
        public string Text { get; set; }
        public ComplaintType Type { get; set; }
        public bool IsResolved { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? Reply { get; set; }

        public Complain() { }

        public Complain( long userId, string text, ComplaintType type, bool isResolved, DateTime createdAt, long? reply)
        {
            UserId = userId;
            Text = text;
            Type = type;
            IsResolved = isResolved;
            CreatedAt = createdAt;
            Reply = reply;
        }
    }

    public enum ComplaintType
    {
        Company,
        Admin
    }
}
