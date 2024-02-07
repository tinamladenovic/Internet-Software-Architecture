using AutoMapper;
using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentCompany.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Account> GetAll()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account Get(int id)
        {
            return _dbContext.Accounts.SingleOrDefault(p => p.Id == id);
        }

        public Account Update(Account account)
        {
            try
            {
                _dbContext.Update(account);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return account;
        }


        public long GetHighestProfileId()
        {
            long highestProfileId = _dbContext.Accounts
                .OrderByDescending(profile => profile.Id)
                .Select(profile => profile.Id)
                .FirstOrDefault();

            return highestProfileId;
        }

        public Account Create(Account account)
        {
            account.Id = GetHighestProfileId() + 1;
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return account;
        }
    }
}
