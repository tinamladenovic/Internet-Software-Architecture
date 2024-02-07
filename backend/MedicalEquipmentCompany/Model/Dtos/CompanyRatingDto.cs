namespace MedicalEquipmentCompany.Model.Dtos
{
    public class CompanyRatingDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public int Rating { get; set; }
        public List<Criteria> Criterias { get; set; }
        public string? Comment { get; set; }
    }
}

public enum Criteria
{
    Efficency,
    Supply,
    CustomerService,
    Punctuality
}
