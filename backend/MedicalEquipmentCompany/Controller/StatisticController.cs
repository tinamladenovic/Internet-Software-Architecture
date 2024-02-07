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
    [Route("api/statistic")]
    public class StatisticController : BaseApiController
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService StatisticService)
        {
            _statisticService = StatisticService;
        }

        [HttpGet]
        public ActionResult<PagedResult<StatisticDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _statisticService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<StatisticDto> Create([FromBody] StatisticDto Statistic)
        {
            var result = _statisticService.Create(Statistic);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<StatisticDto> Update([FromBody] StatisticDto Statistic)
        {
            var result = _statisticService.Update(Statistic);
            return CreateResponse(result);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _statisticService.Delete(id);
            return CreateResponse(result);
        }
    }
}
