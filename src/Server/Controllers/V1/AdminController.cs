namespace Server.Controllers.V1;

public class AdminController : BaseController
{
    private readonly IUserQueryService _userQueryService;

    public AdminController(IUserQueryService userQueryService)
    {
        _userQueryService = userQueryService;
    }

    [HttpGet("Users")]
    public async Task<ActionResult<ResponseModel<List<UserDto>>>> GetUsers(CancellationToken cancellation)
    {
        var result =
            await _userQueryService.GetUsersAsync(cancellation);

        return ResponseModel<List<UserDto>>.Success(value: result.ToList());
    }
}
