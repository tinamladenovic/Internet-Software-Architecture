using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentCompany.Controller
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<PagedResult<AccountDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _accountService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        

        [HttpPost("{id:int}")]
        public ActionResult<AccountDto> Create([FromBody]AccountDto account)
        {
            var result = _accountService.Create(account);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<AccountDto> Update([FromBody] AccountDto account)
        {
            var result = _accountService.Update(account);
            return CreateResponse(result);
        }

        
    }
}
