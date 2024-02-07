using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface ICompanyService
    {
        Result<PagedResult<CompanyDto>> GetPaged(int page, int pageSize);
        Result<CompanyDto> Create(CompanyDto user);
        Result<CompanyDto> Update(CompanyDto user);
        Result<CompanyDto> Get(int id);
        Result Delete(int id);
        Result<PagedResult<CompanyDto>> Search(CompanySearchDto companySearch);
    }
}
