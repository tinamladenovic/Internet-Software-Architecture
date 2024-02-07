using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface IEquipmentService 
    {
        Result<PagedResult<EquipmentDto>> GetPaged(int page, int pageSize);
        Result<EquipmentDto> Create(EquipmentDto user);
        Result<EquipmentDto> Get(int id);
        Result<EquipmentDto> Update(EquipmentDto user);
        Result Delete(int id);
        Result<PagedResult<EquipmentDto>> Search(EquipmentSearchDto companySearch);
        public Result<PagedResult<EquipmentDto>> SearchByCompany(int id);
    }
}
