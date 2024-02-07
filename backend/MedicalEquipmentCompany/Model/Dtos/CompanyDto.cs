namespace MedicalEquipmentCompany.Model.Dtos
{
    public class CompanyDto
    {
        public List<long> AdministratorIds { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double AverageCompanyRating { get; set; }
        //public List<long> EquipmentStock { get;  set; }
        public List<long> CompanyWorkingHours { get;  set; }
    }
}
