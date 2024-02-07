using FluentResults;
using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Repository.Interface;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MedicalEquipmentCompany.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Company> Search(CompanySearchDto companySearch)
        {
            var result = _dbContext.Companies.Where(x => (x.Name.ToLower().Contains(companySearch.Name.ToLower())) && (x.City.ToLower().Contains(companySearch.Address.ToLower()))).ToList();
            return result;
        }
    }
}
