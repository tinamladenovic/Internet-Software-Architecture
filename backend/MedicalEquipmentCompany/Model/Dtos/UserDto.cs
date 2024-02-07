namespace MedicalEquipmentCompany.Model.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string? VerificationToken { get; set; }
        public bool IsActive { get; set; }
    }
}
