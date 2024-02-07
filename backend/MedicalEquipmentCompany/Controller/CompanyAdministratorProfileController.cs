using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentCompany.Controller
{
    [ApiController]
    [Route("api/companyAdministratorProfile")]
    public class CompanyAdministratorProfileController : BaseApiController
    {
        private readonly ICompanyAdministratorProfileService _companyAdministratorProfileService;

        public CompanyAdministratorProfileController(ICompanyAdministratorProfileService companyAdministratorProfileService)
        {
            _companyAdministratorProfileService = companyAdministratorProfileService;
        }

        [HttpGet]
        public ActionResult<PagedResult<CompanyAdministratorProfileDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _companyAdministratorProfileService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CompanyAdministratorProfileDto> Get(int id)
        {
            var result = _companyAdministratorProfileService.Get(id);
            return CreateResponse(result);
        }

        [HttpPost("{id:int}")]
        public ActionResult<CompanyAdministratorProfileDto> Create([FromBody] CompanyAdministratorProfileDto companyAdministratorProfile)
        {
            var result = _companyAdministratorProfileService.Create(companyAdministratorProfile);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CompanyAdministratorProfileDto> Update([FromBody] CompanyAdministratorProfileDto companyAdministratorProfile)
        {
            var result = _companyAdministratorProfileService.Update(companyAdministratorProfile);
            return CreateResponse(result);
        }

        
    }
}
