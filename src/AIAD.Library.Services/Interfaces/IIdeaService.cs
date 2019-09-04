using AIAD.Library.Models;
using System.Collections.Generic;

namespace AIAD.Library.Services.Interfaces
{
    public interface IIdeaService : ICrudService<Idea>
    {
        IEnumerable<Idea> GetByCreatorId(ApplicationContext context, string creatorId);
        IEnumerable<Idea> GetByCreatorUsername(ApplicationContext context, string username);
    }
}
