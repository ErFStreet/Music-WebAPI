namespace Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .HasKey(current => current.Id);

        builder
            .HasQueryFilter(current => !current.IsDeleted);
    }
}
