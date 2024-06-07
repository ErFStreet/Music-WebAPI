namespace Domain.Dtos.User;

public class UserLoginDto
{
    [Required]
    [StringLength(50, ErrorMessage = "Can not be {0} Char")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Can not be {0} Char")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
