using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;
using Clinc_Manegment_System.Repositories;
using Clinc_Manegment_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clinc_Manegment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo accountRepo;
        private readonly IAccountRepo accRepo;
        private readonly ILoginServices loginServices;

        public AccountController(IAccountRepo accountRepo, IAccountRepo AccRepo,ILoginServices loginServices) {
            this.accountRepo = accountRepo;
            accRepo = AccRepo;
            this.loginServices = loginServices;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var checkEmail = accountRepo.isEmailUniqe(model.Email);
            if (checkEmail)
                return BadRequest("Email is already in use.");

            if (model.Password != model.ConfirmPassword)
                return BadRequest("Password and Confirm Password do not match.");

            if (string.IsNullOrEmpty(model.FirstName))
                return BadRequest("First Name is required.");

            var saccess = await accRepo.RegisterUser(model);
            if (saccess.Succeeded) return Ok("User registered successfully.");
            return BadRequest(saccess.Errors);


        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {

            var check = await accountRepo.CheckByEmail(loginDTO.Email);
            if (check)
            {
                var user =await accountRepo.GetByEmail(loginDTO.Email);
                var checkPass = await accountRepo.checkPassword(user, loginDTO.Password);
                if (checkPass)
                {
                    var result = await loginServices.Login(loginDTO);
                    return Ok(result);
                }
                return BadRequest("Email or password invalid");
            }
            return BadRequest("Email or password invalid");

        }

    }
}
