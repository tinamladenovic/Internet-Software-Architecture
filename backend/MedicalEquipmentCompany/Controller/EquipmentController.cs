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
    [Route("api/equipment")]
    public class EquipmentController : BaseApiController
    {
        private readonly IEquipmentService _equipmentyService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentyService = equipmentService;
        }

        [HttpGet]
        public ActionResult<PagedResult<EquipmentDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _equipmentyService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EquipmentDto> Create([FromBody] EquipmentDto address)
        {
            var result = _equipmentyService.Create(address);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EquipmentDto> Update([FromBody] EquipmentDto address)
        {
            var result = _equipmentyService.Update(address);
            return CreateResponse(result);
        }



        [HttpPost("search")]
        public ActionResult<PagedResult<EquipmentDto>> Search([FromBody] EquipmentSearchDto companySearch)
        {
            var result = _equipmentyService.Search(companySearch);
            return CreateResponse(result);
        }

        [HttpPost("search/company")]
        public ActionResult<PagedResult<EquipmentDto>> Search([FromBody] CompanyDto company)
        {
            var result = _equipmentyService.SearchByCompany((int)company.Id);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _equipmentyService.Delete(id);
            return CreateResponse(result);
        }
    }
}
