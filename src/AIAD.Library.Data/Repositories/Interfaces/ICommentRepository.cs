using AIAD.Library.Models;
using System.Linq;

namespace AIAD.Library.Data.Repositories.Interfaces
{
    public interface ICommentRepository : ICrudRepository<Comment>
    {
        IQueryable<Comment> GetByCreatorId(string creatorId);
        IQueryable<Comment> GetByIdeaId(int ideaId);
    }
}
