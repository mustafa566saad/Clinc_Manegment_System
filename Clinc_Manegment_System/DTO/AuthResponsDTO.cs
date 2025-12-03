using System.ComponentModel.DataAnnotations;

namespace Clinc_Manegment_System.DTO
{
    public class AuthResponsDTO
    {
        public required Task<string> Token { get; set; }
        public string UserID { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
