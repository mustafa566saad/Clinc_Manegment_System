using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;
using Clinc_Manegment_System.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Clinc_Manegment_System.Services
{
    public class LoginService: ILoginServices
    {
        private readonly IAccountRepo AccountRepo;
        private readonly IConfiguration Config;
        private readonly UserManager<ApplicationUser> userManager;

        public LoginService(IAccountRepo accountRepo, IConfiguration configuration,UserManager<ApplicationUser> userManager)
    
        {
            AccountRepo = accountRepo;
            Config = configuration;
            this.userManager = userManager;
        }



        public async Task<AuthResponsDTO> Login(LoginDTO loginDTO)
        {
            var user = await AccountRepo.GetByEmail(loginDTO.Email);

            var token =
                 GetJWTTokenAsync(user);
            var authUser = new AuthResponsDTO
            {
                Token = token,
                Email = user.Email,
                UserID = user.Id
            };
            return authUser;
        }

        public async Task<string> GetJWTTokenAsync(ApplicationUser user)
        {

            var Claims = new List<Claim>();
            Claims.Add(new Claim(ClaimTypes.Name, user.Email));
            Claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            var userRoles = await userManager.GetRolesAsync(user);
            Claims.AddRange(from role in userRoles
                            select new Claim(ClaimTypes.Role, role));

            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Config["JWT:Key"]));
            var signingCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: Config["JWT:Issuer"],
                audience: Config["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(60),
                claims: Claims,
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}
