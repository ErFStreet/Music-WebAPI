namespace Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(current => current.Id);

        builder
            .HasQueryFilter(current => !current.IsDeleted);

        builder
            .HasOne(current => current.Role)
            .WithMany(current => current.Users);
    }
}
