using FluentResults;
using MedicalEquipmentCompany.Authentication;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;

namespace MedicalEquipmentCompany.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly ICrudRepository<Account> _accountRepository;
        private readonly IAccountRepository _accountRepository1;
        private readonly IEmailService _emailService;

        public AuthenticationService(IUserRepository userRepository, ITokenGenerator tokenGenerator, ICrudRepository<Account> accountRepository, IAccountRepository accountRepository1, IEmailService emailService)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _accountRepository1 = accountRepository1;
            _emailService = emailService;
        }

        public Result<AuthenticationTokensDto> Login(CredentialsDto credentials)
        {
            var user = _userRepository.GetByName(credentials.Email);
            if (user == null || credentials.Password != user.Password || user.IsActive == false) return Result.Fail(FailureCode.NotFound);

            long personId;
            try
            {
                personId = _userRepository.GetPersonId(user.Id);
            }
            catch (KeyNotFoundException)
            {
                personId = 0;
            }
            return _tokenGenerator.GenerateAccessToken(user, personId);
        }

        public Result<AuthenticationTokensDto> RegisterUser(AccountRegistrationDto account)
        {
            if (_userRepository.Exists(account.Email)) return Result.Fail(FailureCode.NonUniqueUsername);

            try
            {
                if(account.Password != account.ConfirmPassword)
                {
                    Result.Fail("Not same password.");
                }
                var user = new User(account.Email, account.Password, Model.Role.RegistredUser, false);

                // Create the user to get the user ID
                user = _userRepository.Create(user);

                // Create the profile
                var profile = _accountRepository1.Create(new Account(account.Name, account.Surname, account.Email, account.City, account.Country, account.Phone, account.Profession, account.Enterprise, user.Id, true, account.Penalites));

                // Generate and assign the verification token
                var token = _tokenGenerator.GenerateAccessToken(user, profile.Id);
                user.VerificationToken = token.Value.AccessToken;
                user.IsActive = false;
                // Save the updated user with the verification token to the database
                _userRepository.Update(user);

                // Send the verification email
                _emailService.SendVerificationEmail(user.Email, (int)user.Id, user.VerificationToken);

                return token;
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
                // There is a subtle issue here. Can you find it?
            }
        }

        public Result<CredentialsDto> GetUsername(int id)
        {
            CredentialsDto dto = new CredentialsDto()
            {
                Email = _userRepository.Get(id).Email,
                Password = string.Empty
            };
            return dto;
        }

        public Result<List<long>> GetAllUserIds()
        {
            try
            {
                var userIDs = _userRepository.GetAllUserIds();
                return Result.Ok(userIDs);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Result<object> GetUserById(long userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public Result<User> Get(int userId)
        {
            return _userRepository.Get(userId);
        }
    }
}
