using System;

namespace WebApi.Response
{
    public class Result
    {
        public RequestState State { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
    }

    public enum RequestState
    {
        Failed = -1,
        NotAuth = 0,
        Success = 1
    }
}
