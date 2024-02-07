using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface IEquipmentPickupService
    {
        Result<PagedResult<EquipmentPickupDto>> GetPaged(int page, int pageSize);
        Result<EquipmentPickupDto> Create(EquipmentPickupDto user);
        Result<EquipmentPickupDto> Update(EquipmentPickupDto user);
        Result<EquipmentPickupDto> Get(int id);
        Result Delete(int id);
        public Result<PagedResult<EquipmentPickupDto>> SearchByCompany(int id);
    }
}