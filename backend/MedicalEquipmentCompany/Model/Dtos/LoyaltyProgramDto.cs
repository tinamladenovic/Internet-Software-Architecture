namespace MedicalEquipmentCompany.Model.Dtos
{
    public class LoyaltyProgramDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int Points { get; set; }
        public Category PointsCategory { get; set; }
    }

    public enum PointsCategory
    {
        Regular,
        Silver,
        Gold
    }

    public enum Discount
    {
        FivePercent = 5,
        TenPercent = 10,
        TwentyFivePercent = 25
    }
}
