using AutoMapper;
using FluentResults;

using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;
using System.Collections.Generic;

namespace MedicalEquipmentCompany.Service
{
    public class EquipmentReservationService : CrudService<EquipmentReservationDto, EquipmentReservation>, IEquipmentReservationService
    {
        private readonly IEquipmentReservationRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public EquipmentReservationService(ICrudRepository<EquipmentReservation> repository, IEquipmentReservationRepository equipmentRepository, IMapper mapper) : base(repository, mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        
    }
}
