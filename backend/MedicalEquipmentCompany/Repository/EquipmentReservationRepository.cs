using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentCompany.Repository
{
    public class EquipmentReservationRepository : IEquipmentReservationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EquipmentReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
