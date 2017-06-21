using System;
using Microsoft.AspNet.Identity;

namespace JwtService
{
    public class JsonUser : IUser
    {
        public string Id => Guid.NewGuid().ToString();
        public string UserName { get; set; }
    }
}