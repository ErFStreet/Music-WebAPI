namespace Infrastructure.Common.Enums;

public enum HttpResponseType : int
{
    Success = 200,
    UnAuthorized = 401,
    NotFound = 404,
    BadRequest = 400,
}
