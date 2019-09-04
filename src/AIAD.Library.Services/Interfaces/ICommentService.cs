using AIAD.Library.Models;
using System.Collections.Generic;

namespace AIAD.Library.Services.Interfaces
{
    public interface ICommentService : ICrudService<Comment>
    {
        IEnumerable<Comment> GetByIdeaId(ApplicationContext context, int ideaId);
        IEnumerable<Comment> GetByCreatorId(ApplicationContext context, string creatorId);
        IEnumerable<Comment> GetByCreatorUsername(ApplicationContext context, string username);
    }
}
