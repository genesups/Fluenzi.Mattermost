using System.Net;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Client.Internal;

public class MattermostApiException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorId { get; }
    public string DetailedError { get; }
    public string RequestId { get; }
    public Uri? RequestUri { get; }
    public HttpMethod? RequestMethod { get; }

    public MattermostApiException(ApiError error, HttpStatusCode statusCode, Uri? requestUri = null, HttpMethod? requestMethod = null)
        : base(error.Message ?? $"Mattermost API error: {error.Id}")
    {
        StatusCode = statusCode;
        ErrorId = error.Id ?? string.Empty;
        DetailedError = error.DetailedError ?? string.Empty;
        RequestId = error.RequestId ?? string.Empty;
        RequestUri = requestUri;
        RequestMethod = requestMethod;
    }

    public MattermostApiException(string message, HttpStatusCode statusCode, Uri? requestUri = null, HttpMethod? requestMethod = null)
        : base(message)
    {
        StatusCode = statusCode;
        ErrorId = string.Empty;
        DetailedError = string.Empty;
        RequestId = string.Empty;
        RequestUri = requestUri;
        RequestMethod = requestMethod;
    }
}
