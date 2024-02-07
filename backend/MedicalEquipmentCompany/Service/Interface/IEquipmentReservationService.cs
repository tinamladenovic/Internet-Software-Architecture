using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface IEquipmentReservationService
    {
        Result<EquipmentReservationDto> Create(EquipmentReservationDto user);
        public Result<PagedResult<EquipmentReservationDto>> SearchByUserId(int id);
        Result Delete(int id);
        Result<EquipmentReservationDto> Get(int id);
    }
}
