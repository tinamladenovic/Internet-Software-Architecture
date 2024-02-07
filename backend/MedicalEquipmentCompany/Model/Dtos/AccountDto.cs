namespace MedicalEquipmentCompany.Model.Dtos
{
    public class AccountDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string City { get;  set; }
        public string Country { get;  set; }
        public string Phone { get;  set; }
        public string Profession { get;  set; }
        public long UserId { get; set; }
        public bool IsActivate { get; set; }
        public string Enterprise { get;  set; } 
        public int Penalties { get; set; }
    }
}
