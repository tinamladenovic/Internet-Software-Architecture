using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Repository.Interface;

namespace MedicalEquipmentCompany.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EquipmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Equipment> SearchByCompany(int companyId)
        {
            var result = _dbContext.Equipments.Where(x => (x.CompanyId == companyId)).ToList();
            return result;
        }
        public List<Equipment> Search(EquipmentSearchDto companySearch)
        {
            var result = _dbContext.Equipments.Where(x => (x.Name.ToLower().Contains(companySearch.Name.ToLower()))).ToList();
            return result;
        }
    }
}
