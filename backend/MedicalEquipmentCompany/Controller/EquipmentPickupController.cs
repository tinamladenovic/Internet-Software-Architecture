using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Service;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentCompany.Controller
{
    [ApiController]
    [Route("api/equipmentPickup")]
    public class EquipmentPickupController : BaseApiController
    {
        private readonly IEquipmentPickupService _equipmentPickupService;

        public EquipmentPickupController(IEquipmentPickupService equipmentPickupService)
        {
            _equipmentPickupService = equipmentPickupService;
        }

        [HttpGet]
        public ActionResult<PagedResult<EquipmentPickupDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _equipmentPickupService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EquipmentPickupDto> Create([FromBody] EquipmentPickupDto equipmentPickup)
        {
            var result = _equipmentPickupService.Create(equipmentPickup);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<EquipmentPickupDto> Update([FromBody] EquipmentPickupDto equipmentPickup)
        {
            var result = _equipmentPickupService.Update(equipmentPickup);
            return CreateResponse(result);
        }

        [HttpPost("search/dates")]
        public ActionResult<PagedResult<EquipmentPickupDto>> Search([FromBody] CompanyDto company)
        {
            var result = _equipmentPickupService.SearchByCompany((int)company.Id);
            return CreateResponse(result);
        }
    }
}