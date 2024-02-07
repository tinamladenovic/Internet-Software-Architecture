using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface ICompanyAdministratorProfileService
    {
        Result<PagedResult<CompanyAdministratorProfileDto>> GetPaged(int page, int pageSize);
        Result<CompanyAdministratorProfileDto> Create(CompanyAdministratorProfileDto user);
        Result<CompanyAdministratorProfileDto> Update(CompanyAdministratorProfileDto user);
        Result<CompanyAdministratorProfileDto> Get(int id);
        Result Delete(int id);
        
    }
}
