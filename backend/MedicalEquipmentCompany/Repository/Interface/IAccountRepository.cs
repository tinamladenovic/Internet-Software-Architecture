using AutoMapper;
using MedicalEquipmentCompany.Model;

namespace MedicalEquipmentCompany.Repository.Interface
{
    public interface IAccountRepository
    {
        Account Create(Account account);
        List<Account> GetAll();
        Account Get(int id);
        Account Update(Account account);
    }
}
