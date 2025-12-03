using Clinc_Manegment_System.DTO;

namespace Clinc_Manegment_System.Services
{
    public interface ILoginServices
    {
        Task<AuthResponsDTO> Login(LoginDTO loginDTO);

    }
}
