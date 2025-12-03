using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;
using Microsoft.AspNetCore.Identity;
using System.ClientModel.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace Clinc_Manegment_System.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly ClincContext clincContext;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountRepo(ClincContext clincContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInManager)
        {
            this.clincContext = clincContext;
            UserManager = userManager;
            signInManager = SignInManager;
        }

        public async Task<bool> CheckByEmail(string email)
        {
           var result= await UserManager.FindByEmailAsync(email);
            return result != null ? true : false;    
        }
        public async Task<ApplicationUser> GetByEmail(string email)
        {
            var result = await UserManager.FindByEmailAsync(email);
            return result;
        }


        public async Task<bool> checkPassword(ApplicationUser user, string password)
        {
            var check= await UserManager.CheckPasswordAsync(user, password);
            return check;
        }

        public bool isEmailUniqe(string email)
        {
            return clincContext.Users.Any(u => u.Email == email);

        }
        public async Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterUser(RegisterDTO UserData)
        {
            var AppData = new ApplicationUser
            {
                Email = UserData.Email,
                UserName = $"{UserData.FirstName}_{UserData.LastName}",
                PasswordHash = UserData.Password,
                PhoneNumber = UserData.PhoneNumber
            };
            var Data = new Pationts
            {
                Email = UserData.Email,
                FirstName = UserData.FirstName,
                LastName = UserData.LastName,
                DateOfBirth = UserData.DateOfBirth,
                PhoneNumber = UserData.PhoneNumber,
                Address = UserData.Address,
                Password = UserData.Password
            };
            var PationtHash = new PasswordHasher<Pationts>();
            var result = await UserManager.CreateAsync(AppData, AppData.PasswordHash);
            if (result.Succeeded)
            {
                Data.Password = PationtHash.HashPassword(Data, Data.Password);
                await UserManager.AddToRoleAsync(AppData, "Patient");
                await signInManager.SignInAsync(AppData, isPersistent: false);
                clincContext.Pationts.Add(Data);
                await clincContext.SaveChangesAsync();
                return (true, Enumerable.Empty<string>());
            }
            var errorDescriptions = result.Errors.Select(e => e.Description).ToList();
            return (false, errorDescriptions);
        }

    }
}
