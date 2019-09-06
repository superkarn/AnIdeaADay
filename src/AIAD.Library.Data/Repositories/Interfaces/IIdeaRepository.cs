using AIAD.Library.Models;
using System.Linq;

namespace AIAD.Library.Data.Repositories.Interfaces
{
    public interface IIdeaRepository : ICrudRepository<Idea>
    {
        IQueryable<Idea> GetByCreatorId(string creatorId);
    }
}
