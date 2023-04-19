using System.Security.Principal;
using System.Text;

namespace DrugManagementAPI
{
    public class BasicAuthenticationMiddleware
    {

        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var AuthHeader = context.Request.Headers.Authorization;
            var EncodeCredentials = AuthHeader.FirstOrDefault()?.Split(" ").Last();

            var DecodeCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(EncodeCredentials));
            var credentials = DecodeCredentials.Split(':');

            var UserName = credentials[0];
            var Password = credentials[1];


            if (ValidateUser(UserName, Password))
            {
                context.User = new GenericPrincipal(new GenericIdentity(UserName), null);
            }
            else
                return;
            await _next(context);
        }

        public bool ValidateUser(string UserName, string Password)
        {
            if(UserName == "Admin" && Password == "Darshan")
            {
                return true;
            }
            else
                return false;
        }
    }
}
