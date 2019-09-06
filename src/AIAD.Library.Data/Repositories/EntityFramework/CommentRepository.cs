using Microsoft.EntityFrameworkCore;
using System.Linq;
using AIAD.Library.Data.Data;
using AIAD.Library.Models;
using AIAD.Library.Data.Repositories.Interfaces;

namespace AIAD.Library.Data.Repositories.EntityFramework
{
    public class CommentRepository : BaseWithIdRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context)
            : base(context)
        { }

        public override Comment GetById(int id)
        {
            return this.DbSet
                .SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Comment> GetByCreatorId(string creatorId)
        {
            return this.DbSet
                .Where(x => x.CreatorId == creatorId);
        }

        public IQueryable<Comment> GetByIdeaId(int ideaId)
        {
            return this.DbSet
                .Where(x => x.IdeaId == ideaId);
        }
    }
}
