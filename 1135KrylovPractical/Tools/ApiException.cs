using System;
using System.Net;

namespace _1135KrylovPractical.Tools;

public class ApiException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public ApiException(HttpStatusCode code, string message) : base(message)
    {
        StatusCode = code;
    }
}