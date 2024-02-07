using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentCompany.Controller
{
    [ApiController]
    [Route("api/company")]
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService addressService)
        {
            _companyService = addressService;
        }

        [HttpGet]
        public ActionResult<PagedResult<CompanyDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _companyService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CompanyDto> Get(int id)
        {
            var result = _companyService.Get(id);
            return CreateResponse(result);
        }

        [HttpPost("{id:int}")]
        public ActionResult<EquipmentDto> Create([FromBody] CompanyDto address)
        {
            var result = _companyService.Create(address);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EquipmentDto> Update([FromBody] CompanyDto address)
        {
            var result = _companyService.Update(address);
            return CreateResponse(result);
        }

        [HttpPost("search")]
        public ActionResult<PagedResult<EquipmentDto>> Search([FromBody] CompanySearchDto companySearch)
        {
            var result = _companyService.Search(companySearch);
            return CreateResponse(result);
        }
    }
}
