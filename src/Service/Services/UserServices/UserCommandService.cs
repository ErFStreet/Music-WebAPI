namespace Service.Services.UserServices;

public class UserCommandService : IUserCommandService
{
    private readonly IRepository<User> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public UserCommandService(IRepository<User> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;

        _unitOfWork = unitOfWork;
    }

    public async Task<bool> RegisterAsync(UserRegisterDto dto,CancellationToken cancellation)
    {
        var user = new User(
            email: dto.Email!,
            name: dto.Name!,
            surname: dto.Surname!,
            hashPassword: dto.HashPassword!,
            roleId: dto.RoleId
            );

        await _repository.AddAsync(user, cancellation);

        var affectedRows =
          await  _unitOfWork.SaveChangesAsync(cancellation);

        return affectedRows > 0 ? true : false;
    }
}
