namespace Service.Contract;

public interface IUserQueryService
{
    Task<IReadOnlyCollection<UserDto>> GetUsersAsync(CancellationToken cancellation);

    Task<UserDto?> GetUserByIdAsync(int id, CancellationToken cancellation);
}
