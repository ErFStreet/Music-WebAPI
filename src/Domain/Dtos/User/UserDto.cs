namespace Domain.Dtos.User;

public class UserDto
{
    public UserDto()
    {
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? FullName => $"{Name} {Surname}";
}
