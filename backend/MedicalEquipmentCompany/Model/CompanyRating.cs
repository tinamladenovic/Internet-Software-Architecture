using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Model
{
    public class CompanyRating : Entity
    {
        public long UserId { get; set; } 
        public long CompanyId { get; set; } 
        public int Rating { get; set; }
        public List<Criteria> Criterias { get; set; }
        public string? Comment { get; set; }

        public CompanyRating() { }

        public CompanyRating( long userId, long companyId, int rating, List<Criteria> criterias, string? comment)
        {
            UserId = userId;
            CompanyId = companyId;
            Rating = rating;
            Criterias = criterias;
            Comment = comment;
        }
    }

    public enum Criteria
    {
        Efficency,
        Supply,
        CustomerService,
        Punctuality
    }

}
