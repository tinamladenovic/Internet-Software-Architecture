
using MedicalEquipmentCompany.Model.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace MedicalEquipmentCompany.Model;

public class User : Entity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; private set; }
    public string? VerificationToken { get; set; }
    public bool IsActive { get; set; }

    public User(string email, string password, Role role, bool isActive)
    {
        Email = email;
        Password = password;
        Role = role;
        Validate();
        IsActive = isActive;
    }

    private void Validate()
    {

        if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Password.");
        if (!MailAddress.TryCreate(Email, out _)) throw new ArgumentException("Invalid Email adress.");
    }

    public string GetPrimaryRoleName()
    {
        return Role.ToString().ToLower();

    }
}


public enum Role
{
    CompanyAdministrator,
    SystemAdministrator,
    RegistredUser
}