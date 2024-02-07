using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface IAuthenticationService
    {
        Result<AuthenticationTokensDto> Login(CredentialsDto credentials);
        Result<AuthenticationTokensDto> RegisterUser(AccountRegistrationDto account);
        Result<CredentialsDto> GetUsername(int id);
        Result<List<long>> GetAllUserIds();
        Result<object> GetUserById(long userId);
        public Result<User> Get(int userId);
    }
}
