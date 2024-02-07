using AutoMapper;
using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MedicalEquipmentCompany.Service
{
    public class EquipmentService : CrudService<EquipmentDto, Equipment>, IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public EquipmentService(ICrudRepository<Equipment> repository, IEquipmentRepository equipmentRepository, IMapper mapper) : base(repository, mapper)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Result<PagedResult<EquipmentDto>> Search(EquipmentSearchDto companySearch)
        {
            var result = _equipmentRepository.Search(companySearch)
                                           .Select(company =>
                                           {
                                               return new EquipmentDto
                                               {
                                                   Name = company.Name,
                                                   Id = company.Id,
                                                   Description = company.Description,
                                                   Price = company.Price,
                                                   QuantityInStock = company.QuantityInStock,
                                                   Type = company.Type
                                                   
                                               };
                                           }).ToList();
            var pagedResult = new PagedResult<EquipmentDto>(result, result.Count());
            return Result.Ok(pagedResult);
        }

        public Result<PagedResult<EquipmentDto>> SearchByCompany(int id)
        {
            var result = _equipmentRepository.SearchByCompany(id)
                                           .Select(equipment =>
                                           {
                                               return new EquipmentDto
                                               {
                                                   Name = equipment.Name,
                                                   Id = equipment.Id,
                                                   Description = equipment.Description,
                                                   Price = equipment.Price,
                                                   QuantityInStock = equipment.QuantityInStock,
                                                   Type = equipment.Type

                                               };
                                           }).ToList();
            var pagedResult = new PagedResult<EquipmentDto>(result, result.Count());
            return Result.Ok(pagedResult);
        }

        public Result<bool> CheckEquipmentCount(int equipmentId, int wishedCount)
        {
            var equipment = Get(equipmentId);
            if (equipment.Value == null)
            {
                return Result.Fail<bool>("Equipment not found");
            }

            if (equipment.Value.QuantityInStock >= wishedCount)
            {
                return Result.Ok(true);
            }
            else
            {
                return Result.Ok(false);
            }
        }
    }
}
