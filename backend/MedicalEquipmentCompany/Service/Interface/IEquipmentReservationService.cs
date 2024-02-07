using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface IEquipmentReservationService
    {
        Result<EquipmentReservationDto> Create(EquipmentReservationDto user);
        Result<PagedResult<EquipmentReservationDto>> GetPaged(int page, int pageSize);
        Result<EquipmentReservationDto> Update(EquipmentReservationDto user);

        Result<EquipmentReservationDto> Get(int id);
   
    }
}
