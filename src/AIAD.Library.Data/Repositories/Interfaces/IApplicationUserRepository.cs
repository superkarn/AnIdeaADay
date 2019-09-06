using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace AIAD.Library.Data.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        IQueryable<IdentityUser> GetByUsername(string username);
    }
}
