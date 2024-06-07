namespace Service.Services.UserServices;

public class UserQueryService : IUserQueryService
{
    private readonly IRepository<User> _repository;

    public UserQueryService(IRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<UserDto>> GetUsersAsync(CancellationToken cancellation)
    {
        var result =
          await _repository.Queryable
              .Select(current => new UserDto
              {
                  Id = current.Id,
                  Name = current.Name,
                  Surname = current.Surname,
                  Email = current.Email,
              })
              .ToListAsync(cancellation);

        return result;
    }

    public async Task<UserDto?> GetUserByIdAsync(int id, CancellationToken cancellation)
    {
        var result =
            await _repository.Queryable
                .Where(current => current.Id.Equals(id))
                .Select(current=>new UserDto
                {
                    Id = current.Id,
                    Name = current.Name,
                    Surname = current.Surname,
                    Email = current.Email,
                })
                .FirstOrDefaultAsync(cancellation);

        return result;
    }
}
