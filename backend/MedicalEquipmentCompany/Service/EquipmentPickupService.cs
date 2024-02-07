using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Service.Interface;
using AutoMapper;
using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;
using MedicalEquipmentCompany.Repository;
using System.Drawing;

namespace MedicalEquipmentCompany.Service
{
    public class EquipmentPickupService : CrudService<EquipmentPickupDto, EquipmentPickup>, IEquipmentPickupService
    {
        private readonly IEquipmentPickupRepository _equipmentPickupRepository;
        private readonly IMapper _mapper;

        public EquipmentPickupService(ICrudRepository<EquipmentPickup> repository, IEquipmentPickupRepository equipmentPickupRepository, IMapper mapper) : base(repository, mapper)
        {
            _equipmentPickupRepository = equipmentPickupRepository;
            _mapper = mapper;
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
            List<EquipmentPickupDto> final_result = new List<EquipmentPickupDto>();
            foreach (var item in result)
            {
                DateTime itemDateTime = DateTime.Parse(item.DateAndTime);
                TimeSpan timeDifference = itemDateTime - DateTime.Now;

                if (!(Math.Abs(timeDifference.TotalHours) >= 24 && itemDateTime < DateTime.Now))
                {
                    final_result.Add(item);
                }
            }
            var pagedResult = new PagedResult<EquipmentPickupDto>(final_result, final_result.Count());
            return Result.Ok(pagedResult);
        }

        public Result<EquipmentPickupDto> UpdatePickup(EquipmentPickupDto equipmentPickup)
        {
            EquipmentPickup pickupEntity = _mapper.Map<EquipmentPickup>(equipmentPickup);
            var result = _equipmentPickupRepository.Update(pickupEntity);
            EquipmentPickupDto final_result = _mapper.Map<EquipmentPickupDto>(result);
            return Result.Ok(final_result);
        }
    }
}