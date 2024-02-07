using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Interface
{
    public interface IStatisticService
    {
        Result<PagedResult<StatisticDto>> GetPaged(int page, int pageSize);
        Result<StatisticDto> Create(StatisticDto user);
        Result<StatisticDto> Update(StatisticDto user);
        Result<StatisticDto> Get(int id);
        Result Delete(int id);

        Result<double> GetAverageCompanyRating();
        Result<List<int>> GetMonthlyTermCounts(int year, int month);
        Result<List<int>> GetQuarterlyTermCounts(int year, int quarter);
        Result<List<int>> GetYearlyTermCounts(int year);
        Result<List<int>> GetMonthlyReservationCounts(int year, int month);
        Result<List<int>> GetQuarterlyReservationCounts(int year, int quarter);
        Result<List<int>> GetYearlyReservationCounts(int year);
    }
}
