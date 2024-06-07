namespace Service.Contract;

public interface IUserCommandService
{
    Task<bool> RegisterAsync(UserRegisterDto dto, CancellationToken cancellation);
}
