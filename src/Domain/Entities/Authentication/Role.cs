namespace Domain.Entities.Authentication;

public class Role : BaseEntity<int> , IEntityHasIsDeleted
{
    public Role(string roleName)
    {
        RoleName = roleName;
    }

    [Required]
    [StringLength(30, ErrorMessage = "Can not be {0} Char")]
    public string RoleName { get; set; }

    public bool IsDeleted { get; set; }

    #region Relations
    public virtual List<User>? Users { get; set; }
    #endregion
}
