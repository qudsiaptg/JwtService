using Microsoft.AspNet.Identity;

namespace JwtService
{
    public class JSonIdentityProvider
    {
        public IUser GetUser()
        {
            return new JsonUser { UserName = "JsTest"};
        }
    }
}