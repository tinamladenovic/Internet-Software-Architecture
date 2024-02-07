using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentCompany.Controller
{
    [ApiController]
    [Route("api/companyWorkingHours")]
    public class CompanyWorkingHoursController : BaseApiController
    {
        private readonly ICompanyWorkingHoursService _companyWorkingHoursService;

        public CompanyWorkingHoursController(ICompanyWorkingHoursService companyWorkingHoursService)
        {
            _companyWorkingHoursService = companyWorkingHoursService;
        }

        [HttpGet]
        public ActionResult<PagedResult<CompanyWorkingHoursDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _companyWorkingHoursService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CompanyWorkingHoursDto> Get(int id)
        {
            var result = _companyWorkingHoursService.Get(id);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<CompanyWorkingHoursDto> Create([FromBody] CompanyWorkingHoursDto companyWorkingHours)
        {
            var result = _companyWorkingHoursService.Create(companyWorkingHours);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<CompanyWorkingHoursDto> Update([FromBody] CompanyWorkingHoursDto companyWorkingHours)
        {
            var result = _companyWorkingHoursService.Update(companyWorkingHours);
            return CreateResponse(result);
        }

    }
}
