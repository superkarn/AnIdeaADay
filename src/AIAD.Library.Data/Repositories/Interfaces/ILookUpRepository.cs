using AIAD.Library.Models;
using System.Linq;

namespace AIAD.Library.Data.Repositories.Interfaces
{
    public interface ILookUpRepository<TEntity> where TEntity : BaseLookUpModel
    {
        IQueryable<TEntity> GetAll();
    }
}
