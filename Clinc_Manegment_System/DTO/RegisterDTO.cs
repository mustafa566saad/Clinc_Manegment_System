using System.ComponentModel.DataAnnotations;

namespace Clinc_Manegment_System.DTO
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]

        [Compare("Password",ErrorMessage = "Password and Confirm Password isn't matchs")]
        public string ConfirmPassword { get; set; }

    }
}
