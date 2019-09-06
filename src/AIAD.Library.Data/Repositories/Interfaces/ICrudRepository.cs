using AIAD.Library.Models;

namespace AIAD.Library.Data.Repositories.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity : BaseWithIdModel
    {
        int Create(TEntity item);
        void DeleteById(int id);
        TEntity GetById(int id);
        void Update(TEntity item);
    }
}
