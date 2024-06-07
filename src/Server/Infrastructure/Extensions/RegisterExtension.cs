namespace Server.Infrastructure.Extensions;

public static class RegisterExtension
{
    public static void Register(this IServiceCollection services)
    {
        // Register Services 

        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
    }

    public static void Register(this WebApplication app)
    {
        // Register Application

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI();
        }

        app.InitializeDataBase();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }

    public static void RegisterDbContext(this WebApplicationBuilder builder)
    {
        // Register Database

        var connectionString =
            builder.Configuration["Database:ConnectionString"];

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString: connectionString);
        });
    }

    public static void RegisterDependencyInjection(this IServiceCollection service)
    {
        // Register Dependency Injection

        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        service.AddScoped<IUnitOfWork, UnitOfWork>();

        service.AddScoped<IUserCommandService, UserCommandService>();

        service.AddScoped<IUserQueryService, UserQueryService>();

    }

    private static void InitializeDataBase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateAsyncScope();

        var databaseContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (!databaseContext.Roles!.Any()) return;
        
        var roles = new List<Role>()
        {
            new Role(nameof(RoleType.SuperAdmin)),

            new Role(nameof(RoleType.Admin)),

            new Role(nameof(RoleType.User)),

            new Role(nameof(RoleType.Vip)),
        };

        databaseContext.AddRange(roles);

        var affectedRows =
            databaseContext.SaveChanges();

        if (affectedRows <= 0)
            throw new ApplicationException();

        if (databaseContext.Users!.Any()) return;

        var user = new User(
            name: "Erfan",
            surname: "Edalati",
            email: "ErfannStreet@gmail.com",
            hashPassword: "Erfan@8909$#",
            roleId: 1
        );

        databaseContext.Add(user);

        var result =
            databaseContext.SaveChanges();

        if (result <= 0)
            throw new ApplicationException();
    }
}