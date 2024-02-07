using FluentResults;
using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Repository.Interface;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MedicalEquipmentCompany.Repository
{
    public class CompanyWorkingHoursRepository : ICompanyWorkingHoursRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyWorkingHoursRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
