namespace Server.Controllers.V1;

public class AuthenticationController : BaseController
{
    private readonly IUserCommandService _userCommandService;

    public AuthenticationController(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<ResponseModel>> Register(UserRegisterDto? dto, CancellationToken cancellation)
    {
        if (dto is null)
            return ResponseModel.BadRequest();

        var result =
            await _userCommandService.RegisterAsync(dto, cancellation);

        return result ? ResponseModel.Success() : ResponseModel.NotFound();
    }
}