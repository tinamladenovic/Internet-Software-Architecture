using FluentResults;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Model.Dtos;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface IAccountService
    {
        Result<PagedResult<AccountDto>> GetPaged(int page, int pageSize);
        Result<AccountDto> Create(AccountDto user);
        Result<AccountDto> Update(AccountDto user);
        Result Delete(int id);
    }
}
