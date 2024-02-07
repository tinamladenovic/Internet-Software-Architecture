using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Service;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MedicalEquipmentCompany.Controller
{
    [ApiController]
    [Route("api/equipment")]
    public class EquipmentController : BaseApiController
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public ActionResult<PagedResult<EquipmentDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _equipmentService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EquipmentDto> Create([FromBody] EquipmentDto address)
        {
            var result = _equipmentService.Create(address);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EquipmentDto> Update([FromBody] EquipmentDto address)
        {
            var result = _equipmentService.Update(address);
            return CreateResponse(result);
        }

        [HttpPost("search")]
        public ActionResult<PagedResult<EquipmentDto>> Search([FromBody] EquipmentSearchDto companySearch)
        {
            var result = _equipmentService.Search(companySearch);
            return CreateResponse(result);
        }

        [HttpPost("search/company")]
        public ActionResult<PagedResult<EquipmentDto>> Search([FromBody] CompanyDto company)
        {
            var result = _equipmentService.SearchByCompany((int)company.Id);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<EquipmentDto> Get(int id)
        {
            var result = _equipmentService.Get(id);
            return CreateResponse(result);
        }

        [Authorize(Policy = "registredUserPolicy")]
        [HttpGet("checkcount/{id:int}")]
        public ActionResult<bool> CheckCount(int id, [FromQuery] int wishedCount)
        {
            var result = _equipmentService.CheckEquipmentCount(id, wishedCount);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return NotFound(result.Errors);
            }
        }

    }
}
