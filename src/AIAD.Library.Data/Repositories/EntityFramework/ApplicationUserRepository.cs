using AIAD.Library.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AIAD.Library.Data.Repositories.EntityFramework
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        protected readonly IdentityDbContext Context;
        protected readonly DbSet<IdentityUser> DbSet;

        public ApplicationUserRepository(IdentityDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<IdentityUser>();
        }

        public IQueryable<IdentityUser> GetByUsername(string username)
        {
            return this.DbSet.Where(x => x.UserName.ToUpper() == username.ToUpper());
        }
    }
}
