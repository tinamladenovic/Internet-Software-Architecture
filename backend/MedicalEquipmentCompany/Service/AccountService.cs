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
    public class AccountService : CrudService<AccountDto, Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(ICrudRepository<Account> repository, IAccountRepository accountRepository, IMapper mapper) : base(repository, mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        Result<AccountDto> IAccountService.GetByUserId(int id)
        {
            var accounts = GetPaged(1, 1).Value.Results;
            AccountDto final_result = new AccountDto();
            foreach (var account in accounts)
            {
                if(account.UserId == id)
                {
                    final_result = account;
                }
            }
            return Result.Ok(final_result);
        }

        Result<AccountDto> IAccountService.UpdatePenalties(AccountDto user)
        {
            Account accountEntity = _mapper.Map<Account>(user);
            var result = _accountRepository.UpdatePenalties(accountEntity);
            AccountDto final_result = _mapper.Map<AccountDto>(result);
            return Result.Ok(final_result);
        }
    }
}
