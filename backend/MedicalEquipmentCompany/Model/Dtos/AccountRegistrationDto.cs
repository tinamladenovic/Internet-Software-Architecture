namespace MedicalEquipmentCompany.Model.Dtos
{
    public class AccountRegistrationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Profession {  get; set; }
        public string Enterprise { get;  set; } 
        public int Penalites { get; set; }
    }
}
