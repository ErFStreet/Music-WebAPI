namespace Data;

public class ApplicationDbContext : DbContext
{
    #region MyRegion
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    #endregion
    
    #region Properties
    public DbSet<User>? Users { get; set; }

    public DbSet<Role>? Roles { get; set; }
    #endregion

    #region Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        base.OnModelCreating(modelBuilder);
    }
    #endregion
}
