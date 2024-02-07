namespace MedicalEquipmentCompany.Model.Dtos
{
    public class UserAccountDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; }
    }

    public enum Role
    {
        CompanyAdministrator,
        SystemAdministrator,
        RegistredUser
    }
}
