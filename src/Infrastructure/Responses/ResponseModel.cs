namespace Infrastructure.Responses;

public class ResponseModel
{
    public ResponseModel()
    {
        StatusMessages = new();
    }

    public int StatusCode { get; set; }

    public List<string> StatusMessages { get; set; }


    #region Methods
    public static ResponseModel Success()
    {
        return new ResponseModel
        {
            StatusCode = (int)HttpResponseType.Success,

            StatusMessages = new List<string> { ResponseMessage.Success }
        };
    }

    public static ResponseModel BadRequest()
    {
        return new ResponseModel
        {
            StatusCode = (int)HttpResponseType.BadRequest,

            StatusMessages = new List<string> { ResponseMessage.BadRequest }
        };
    }

    public static ResponseModel NotFound()
    {
        return new ResponseModel
        {
            StatusCode = (int)HttpResponseType.NotFound,

            StatusMessages = new List<string> { ResponseMessage.NotFound }
        };
    }
    #endregion
}

public class ResponseModel<TValue> : ResponseModel
{
    public TValue? Value { get; set; }

    public static ResponseModel<TValue> Success(TValue value) 
    {
        return new ResponseModel<TValue>
        {
            Value = value,

            StatusCode = (int)HttpResponseType.Success,

            StatusMessages = new List<string> { ResponseMessage.Success }
        };
    }
}
