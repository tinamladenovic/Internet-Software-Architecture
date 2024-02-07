using FluentResults;
using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Repository.Interface;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MedicalEquipmentCompany.Repository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StatisticRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public double GetAverageCompanyRating()
        {
            var companies = _dbContext.Companies.ToList();

            if (companies.Any())
            {
                double averageRating = companies.Average(company => company.AverageCompanyRating);
                return averageRating;
            }
            else
            {
                return 0; // Nema kompanija, prosečna ocena je 0
            }
        }

        public Result<List<int>> GetMonthlyReservationCounts(int year, int month)
        {
            try
            {
                var reservationCounts = _dbContext.EquipmentReservations
                    .Where(r => r.ReservationDate.Year == year && r.ReservationDate.Month == month)
                    .GroupBy(r => r.ReservationDate.Day)
                    .Select(group => group.Count())
                    .ToList();

                return Result.Ok(reservationCounts);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<int>>(ex.Message);
            }
        }

        public Result<List<int>> GetMonthlyTermCounts(int year, int month)
        {
            try
            {
                var termCounts = _dbContext.EquipmentPickups
                    .Where(p => p.DateAndTime.Year == year && p.DateAndTime.Month == month)
                    .GroupBy(p => p.DateAndTime.Day)
                    .Select(group => group.Count())
                    .ToList();

                return Result.Ok(termCounts);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<int>>(ex.Message);
            }
        }

        public Result<List<int>> GetQuarterlyReservationCounts(int year, int quarter)
        {
            try
            {
                var startMonth = (quarter - 1) * 3 + 1;
                var endMonth = startMonth + 2;

                var reservationCounts = _dbContext.EquipmentReservations
                    .Where(r => r.ReservationDate.Year == year && r.ReservationDate.Month >= startMonth && r.ReservationDate.Month <= endMonth)
                    .GroupBy(r => r.ReservationDate.Month)
                    .Select(group => group.Count())
                    .ToList();

                return Result.Ok(reservationCounts);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<int>>(ex.Message);
            }
        }

        public Result<List<int>> GetQuarterlyTermCounts(int year, int quarter)
        {
            try
            {
                var termCounts = _dbContext.EquipmentPickups
                    .Where(p => p.DateAndTime.Year == year && (p.DateAndTime.Month - 1) / 3 + 1 == quarter)
                    .GroupBy(p => p.DateAndTime.Month)
                    .Select(group => group.Count())
                    .ToList();

                return Result.Ok(termCounts);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<int>>(ex.Message);
            }
        }

        public Result<List<int>> GetYearlyReservationCounts(int year)
        {
            try
            {
                var reservationCounts = _dbContext.EquipmentReservations
                    .Where(r => r.ReservationDate.Year == year)
                    .GroupBy(r => r.ReservationDate.Month)
                    .Select(group => group.Count())
                    .ToList();

                return Result.Ok(reservationCounts);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<int>>(ex.Message);
            }
        }

        public Result<List<int>> GetYearlyTermCounts(int year)
        {
            try
            {
                var termCounts = _dbContext.EquipmentPickups
                    .Where(p => p.DateAndTime.Year == year)
                    .GroupBy(p => p.DateAndTime.Month)
                    .Select(group => group.Count())
                    .ToList();

                return Result.Ok(termCounts);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<int>>(ex.Message);
            }
        }
    
    }
}
