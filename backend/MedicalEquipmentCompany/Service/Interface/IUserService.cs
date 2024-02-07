using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface IUserService
    {
        Result<PagedResult<UserDto>> GetPaged(int page, int pageSize);
        Result<UserDto> Create(UserDto user);
        Result<UserDto> Update(UserDto user);
        Result<UserDto> GetByEmail(User user);
        Result<UserDto> Get(int id);
        Result<UserDto> GetById(int id);
    }
}
