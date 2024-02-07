using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public class LoyaltyClassEntry : Entity
    {
        public int ClassId { get; private set; }
        public int Scale { get; private set; }
        public LoyaltyClassEntry (int classId, int scale)
        {
            ClassId = classId;
            Scale = scale;
        }
    }
}
