using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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

        public EquipmentPickup Update(EquipmentPickup updatedEntity)
        {
            try
            {
                var existingEntity = _dbContext.EquipmentPickups.Find(updatedEntity.Id);

                if (existingEntity == null)
                {
                    throw new KeyNotFoundException($"EquipmentPickup with Id {updatedEntity.Id} not found.");
                }

                // Detach the existing entity before attaching the updated one
                _dbContext.Entry(existingEntity).State = EntityState.Detached;

                // Set the state of the updated entity to Modified
                _dbContext.Entry(updatedEntity).State = EntityState.Modified;

                // Save the changes
                _dbContext.SaveChanges();

                return updatedEntity;
            }
            catch (DbUpdateException e)
            {
                // Handle the exception or rethrow with more specific information
                throw new ApplicationException($"Error updating EquipmentPickup: {e.Message}");
            }
        }

    }
}