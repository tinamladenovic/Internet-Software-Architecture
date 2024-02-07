using AutoMapper;
using FluentResults;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Repository;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;

namespace MedicalEquipmentCompany.Service
{
    public class UserService : CrudService<UserDto, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(ICrudRepository<User> repository, IMapper mapper, IUserRepository userRepository) : base(repository, mapper) {
        _userRepository = userRepository;
        }

        public Result<UserDto> GetByEmail(User user)
        {
            var result = _userRepository.GetByName(user.Email);
            if (result != null)
            {
                return Result.Ok(MapToDto(result));
            } else
            {
                return Result.Fail("User not found.");
            }

        }

        public Result<UserDto> GetById(int id)
        {
            User user = _userRepository.GetById(id);
            return MapToDto(user);
        }
    }
}
