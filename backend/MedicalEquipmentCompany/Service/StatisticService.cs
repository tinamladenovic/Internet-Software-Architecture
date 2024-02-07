using AutoMapper;
using FluentResults;
using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Repository;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalEquipmentCompany.Service
{
    public class StatisticService : CrudService<StatisticDto, Statistic>, IStatisticService
    {
        private readonly IStatisticRepository _statisticRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public StatisticService(ICrudRepository<Statistic> repository, IStatisticRepository statisticRepository, IMapper mapper, ApplicationDbContext dbContext) : base(repository, mapper)
        {
            _statisticRepository = statisticRepository;
            _dbContext = dbContext;
        }

        public Result<double> GetAverageCompanyRating()
        {
            try
            {
                // Pristupite kompanijama iz baze podataka
                var companies = _dbContext.Companies.ToList();

                if (companies.Any())
                {
                    // Izračunajte prosečnu ocenu svih kompanija
                    double averageRating = companies.Average(company => company.AverageCompanyRating);
                    return Result.Ok(averageRating);
                }
                else
                {
                    return Result.Ok<double>(0); 
                                                
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<double>(ex.Message);
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
            return _statisticRepository.GetMonthlyTermCounts(year, month);
        }

        public Result<List<int>> GetQuarterlyReservationCounts(int year, int quarter)
        {
            try
            {
                var reservationCounts = _dbContext.EquipmentReservations
                    .Where(r => r.ReservationDate.Year == year && GetQuarter(r.ReservationDate) == quarter)
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

        private int GetQuarter(DateTime date)
        {
            if (date.Month >= 1 && date.Month <= 3)
            {
                return 1;
            }
            else if (date.Month >= 4 && date.Month <= 6)
            {
                return 2;
            }
            else if (date.Month >= 7 && date.Month <= 9)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public Result<List<int>> GetQuarterlyTermCounts(int year, int quarter)
        {
            return _statisticRepository.GetQuarterlyTermCounts(year, quarter);
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
            return _statisticRepository.GetYearlyTermCounts(year);
        }
    }
}
