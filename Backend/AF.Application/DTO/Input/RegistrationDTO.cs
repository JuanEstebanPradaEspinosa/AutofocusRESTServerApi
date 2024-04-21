using System.ComponentModel.DataAnnotations;

namespace AF.Application.DTO.Input
{
    public class RegistrationDTO
    {
        [Required]
        public string? Name { get; set; } = string.Empty;
        [Required]
        public string? LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Required]
        public string? PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; } = string.Empty;
        [Required, Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; } = string.Empty;
        public byte[]? ProfilePicture { get; set; }
    }
}
