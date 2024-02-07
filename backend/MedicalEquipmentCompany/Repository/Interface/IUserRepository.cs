using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Repository.Interface
{
    public interface IUserRepository
    {
        bool Exists(string username);
        User? GetByName(string username);
        User Create(User user);
        long GetPersonId(long userId);
        User Get(int id);
        List<long> GetAllUserIds();
        Result<object> GetUserById(long userId);
        public Result GetUserById(int userId);
        User Update(User user);
    }
}
