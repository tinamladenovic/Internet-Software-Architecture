using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Service.Interface;
using AutoMapper;
using FluentResults;

using MedicalEquipmentCompany.Model.Result;

using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;


namespace MedicalEquipmentCompany.Service
{
    public class EquipmentPickupService : CrudService<EquipmentPickupDto, EquipmentPickup>, IEquipmentPickupService
    {
        private readonly IEquipmentPickupRepository _equipmentPickupRepository;
        private readonly IMapper _mapper;

        public EquipmentPickupService(ICrudRepository<EquipmentPickup> repository, IEquipmentPickupRepository equipmentPickupRepository, IMapper mapper) : base(repository, mapper)
        {
            _equipmentPickupRepository = equipmentPickupRepository;
        }

        public Result<PagedResult<EquipmentPickupDto>> SearchByCompany(int id)
        {
            var result = _equipmentPickupRepository.SearchByCompany(id)
                                           .Select(equipment =>
                                           {
                                               return new EquipmentPickupDto
                                               {
                                                   AdministratorId = equipment.AdministratorId,
                                                   CompanyId = equipment.CompanyId,
                                                   DateAndTime = equipment.DateAndTime,
                                                   Duration = equipment.Duration,
                                                   IsReserved = equipment.IsReserved,     
                                                   Id = equipment.Id
                                               };
                                           }).ToList();
            var pagedResult = new PagedResult<EquipmentPickupDto>(result, result.Count());
            return Result.Ok(pagedResult);
        }

    }
}