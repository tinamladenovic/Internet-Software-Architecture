using AutoMapper;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;

namespace MedicalEquipmentCompany.Service
{
    public class AccountService : CrudService<AccountDto, Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(ICrudRepository<Account> repository, IAccountRepository accountRepository, IMapper mapper) : base(repository, mapper)
        {
            _accountRepository = accountRepository;
        }
    }
}
