using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Repository.Interface;

namespace MedicalEquipmentCompany.Repository
{
    public class EquipmentPickupRepository : IEquipmentPickupRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EquipmentPickupRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<EquipmentPickup> SearchByCompany(int companyId)
        {
            var result = _dbContext.EquipmentPickups.Where(x => (x.CompanyId == companyId) && (x.IsReserved == false)).ToList();
            return result;
        }
    }
}