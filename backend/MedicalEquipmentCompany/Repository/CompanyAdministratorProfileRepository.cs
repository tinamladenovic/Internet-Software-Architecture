using FluentResults;
using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Repository.Interface;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MedicalEquipmentCompany.Repository
{
    public class CompanyAdministratorProfileRepository : ICompanyAdministratorProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyAdministratorProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
