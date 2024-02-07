using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MedicalEquipmentCompany.Controller
{
    [ApiController]
    [Route("api/users")]

    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService, IUserRepository userRepository)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost]
        public ActionResult<AuthenticationTokensDto> RegisterUser([FromBody] AccountRegistrationDto account)
        {
            var result = _authenticationService.RegisterUser(account);
            return CreateResponse(result);
        }

        [HttpGet("verifyemail")]
        public IActionResult VerifyEmail([FromQuery] int userId, [FromQuery] string token)
        {
            // Retrieve the user from the database based on userId
            var user = _authenticationService.Get(userId);

            if (user != null && user.Value.VerificationToken == token)
            {
                // Check if the token is valid
                //var result = _userService.GetByEmail(user.Value);
                user.Value.IsActive = true;
                _userRepository.Update(user.Value);

                return Ok(new { status = "success", message = "Email verification successful." });
            }
            else
            {
                // Redirect to a page indicating an invalid verification attempt
                return BadRequest(new { status = "error", message = "Invalid verification attempt." });
            }
        }


        [HttpPost("login")]
        public ActionResult<AuthenticationTokensDto> Login([FromBody] CredentialsDto credentials)
        {
            CredentialsDto dto = new CredentialsDto { Password = credentials.Password, Username = credentials.Username };
            var result = _authenticationService.Login(dto);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CredentialsDto> GetUsernameById(int id)
        {
            var result = _authenticationService.GetUsername(id);
            return CreateResponse(result);
        }

        [HttpGet("userids")]
        public ActionResult<List<long>> GetAllUserIds()
        {
            var result = _authenticationService.GetAllUserIds();
            return CreateResponse(result);
        }

        [HttpGet("{userId}")]
        public ActionResult<UserAccountDto> GetUserById(long userId)
        {
            var result = _authenticationService.GetUserById(userId);

            if (result.IsFailed)
            {
                // Handle the failure, e.g., return a 404 (Not Found) response or appropriate error response.
                return NotFound();
            }

            return Ok(result.Value); // Return the user information as a successful response.
        }
    }
}
