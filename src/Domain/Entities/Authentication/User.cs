namespace Domain.Entities.Authentication;

public class User : BaseEntity<int> , IEntityHasIsSystemic , IEntityHasIsDeleted
{
    public User(string name,
        string surname,
        string email,
        string hashPassword,
        int roleId)
    {
        Name = name;

        Surname = surname;

        Email = email;

        HashPassword = hashPassword;

        RoleId = roleId;
    }

    [Required]
    [StringLength(30, ErrorMessage = "Can not be {0} Char")]
    public string Name { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "Can not be {0} Char")]
    public string Surname { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Can not be {0} Char")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Can not be {0} Char")]
    [DataType(DataType.Password)]
    public string HashPassword { get; set; }

    public bool IsSystemic { get; set; }

    public bool IsDeleted { get; set; }

    [Required]
    public int RoleId { get; set; }

    #region Relations
    public virtual Role? Role { get; set; }
    #endregion
}
