using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentCompany.Controller;

[ApiController]
[Route("api/")]
public class UserController : BaseApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<PagedResult<UserDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _userService.GetPaged(page, pageSize);
        return CreateResponse(result);
    }

    [HttpPost("{id:int}")]
    public ActionResult<UserDto> Create([FromBody] UserDto user)
    {
        var result = _userService.Create(user);
        return CreateResponse(result);
    }

    [HttpPut("{id:int}")]
    public ActionResult<UserDto> Update([FromBody] UserDto user)
    {
        var result = _userService.Update(user);
        return CreateResponse(result);
    }
}
