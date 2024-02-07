using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public enum Category
    {
        Regular,
        Silver,
        Gold
    }


    public class LoyaltyProgram : Entity
    {
        public long UserId { get; private set; }
        public int Points { get; private set; }
        public Category PointsCategory { get; private set; }

        public LoyaltyProgram() { }

        public LoyaltyProgram( long userId, int points, Category pointsCategory)
        {
            UserId = userId;
            Points = points;
            PointsCategory = pointsCategory;
        }
    }

    
}
