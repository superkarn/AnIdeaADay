using Microsoft.EntityFrameworkCore;
using System.Linq;
using AIAD.Library.Data.Data;
using AIAD.Library.Models;
using AIAD.Library.Data.Repositories.Interfaces;

namespace AIAD.Library.Data.Repositories.EntityFramework
{
    public class IdeaRepository : BaseWithIdRepository<Idea>, IIdeaRepository
    {
        public IdeaRepository(ApplicationDbContext context)
            : base(context)
        { }

        public override Idea GetById(int id)
        {
            return this.DbSet
                .Include(x => x.Privacy)
                .SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Idea> GetByCreatorId(string creatorId)
        {
            return this.DbSet
                .Include(x => x.Privacy)
                .Where(x => x.CreatorId == creatorId);
        }
    }
}
