using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public class Discount : Entity
    {
        public int ClassId { get; private set; }
        public int DiscountPrecentage { get; private set; }
        public Discount(int classId, int discountPrecentage)
        {
            ClassId = classId;
            DiscountPrecentage = discountPrecentage;
        }
    }
}
