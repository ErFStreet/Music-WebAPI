namespace Server;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // *** Register Database ***

        builder.RegisterDbContext();

        // ************************
        
        // *** Register Service ***

        builder.Services.Register();

        // ************************

        // Register Dependency Injection

        builder.Services.RegisterDependencyInjection();

        // ************************

        var app = builder.Build();

        // *** Register Application ***

        app.Register();

        // ************************

        // *** Run Application ***

        app.Run();

        // ************************
    }
}
