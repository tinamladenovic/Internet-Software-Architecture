using AutoMapper;
using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Repository;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;

namespace MedicalEquipmentCompany.Service
{
    public class EquipmentReservationService : CrudService<EquipmentReservationDto, EquipmentReservation>, IEquipmentReservationService
    {
        private readonly IEquipmentReservationRepository _equipmentReservationRepository;
        private readonly IMapper _mapper;

        public EquipmentReservationService(ICrudRepository<EquipmentReservation> repository, IEquipmentReservationRepository equipmentRepository, IMapper mapper) : base(repository, mapper)
        {
            _equipmentReservationRepository = equipmentRepository;
        }

        public Result<PagedResult<EquipmentReservationDto>> SearchByUserId(int id)
        {
            var result = _equipmentReservationRepository.SearchByUserId(id)
                                           .Select(reservation =>
                                           {
                                               return new EquipmentReservationDto
                                               {
                                                   CompanyId = reservation.CompanyId,
                                                   UserId = reservation.UserId,
                                                   ReservationDate = reservation.ReservationDate,
                                                   ReservationStatus = reservation.ReservationStatus,
                                                   ReservedEquipment = reservation.ReservedEquipment,
                                                   EquipmentCount = reservation.EquipmentCount,
                                                   EquipmentPickup = reservation.EquipmentPickup,
                                                   Id = reservation.Id
                                               };
                                           }).ToList();
            var pagedResult = new PagedResult<EquipmentReservationDto>(result, result.Count());
            return Result.Ok(pagedResult);
        }
    }
}
