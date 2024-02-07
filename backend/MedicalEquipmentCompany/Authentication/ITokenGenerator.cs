using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model;

namespace MedicalEquipmentCompany.Authentication
{
    public interface ITokenGenerator
    {
        Result<AuthenticationTokensDto> GenerateAccessToken(User user, long personId);
    }
}
