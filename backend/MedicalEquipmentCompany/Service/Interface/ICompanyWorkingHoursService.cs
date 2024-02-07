using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface ICompanyWorkingHoursService
    {
        Result<PagedResult<CompanyWorkingHoursDto>> GetPaged(int page, int pageSize);
        Result<CompanyWorkingHoursDto> Create(CompanyWorkingHoursDto user);
        Result<CompanyWorkingHoursDto> Update(CompanyWorkingHoursDto user);
        Result<CompanyWorkingHoursDto> Get(int id);
        Result Delete(int id);
        
    }
}
