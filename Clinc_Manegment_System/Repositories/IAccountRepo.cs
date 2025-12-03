using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;

namespace Clinc_Manegment_System.Repositories
{
    public interface IAccountRepo
    {
        public Task<bool> CheckByEmail(string email);
        public Task<bool> checkPassword(ApplicationUser user, string password);
        public Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterUser(RegisterDTO UserData);
        public Task<ApplicationUser> GetByEmail(string email);
        public bool isEmailUniqe(string email);

    }
}