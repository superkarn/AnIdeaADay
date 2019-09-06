using AIAD.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace AIAD.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public ApplicationContext Context;

        public BaseController()
        {
        }

        protected ApplicationContext CreateApplicationContext(ClaimsIdentity identity)
        {
            return new ApplicationContext()
            {
                CurrentUser = new ApplicationUser()
                {
                    Id = identity.Claims.FirstOrDefault(x => x.Type == "userId").Value,
                    UserName = identity.Claims.FirstOrDefault(x => x.Type == "username").Value
                }
            };
        }
    }
}
