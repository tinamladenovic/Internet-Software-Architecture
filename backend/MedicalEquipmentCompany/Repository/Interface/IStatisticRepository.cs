using FluentResults;
using System;
using System.Collections.Generic;

namespace MedicalEquipmentCompany.Repository.Interface
{
    public interface IStatisticRepository
    {
        double GetAverageCompanyRating();
        Result<List<int>> GetMonthlyTermCounts(int year, int month);
        Result<List<int>> GetQuarterlyTermCounts(int year, int quarter);
        Result<List<int>> GetYearlyTermCounts(int year);

        Result<List<int>> GetMonthlyReservationCounts(int year, int month);
        Result<List<int>> GetQuarterlyReservationCounts(int year, int quarter);
        Result<List<int>> GetYearlyReservationCounts(int year);
    }
}

