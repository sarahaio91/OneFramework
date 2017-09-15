using System;

namespace OneFramework.Auth.WebApi.Response
{
    public class UserData : ResultData
    {
        public DateTime RequestAt { get; set; }
        public double ExpireIn { get; set; }
        public string TokenType { get; set; }
        public string Token { get; set; }
    }
}
