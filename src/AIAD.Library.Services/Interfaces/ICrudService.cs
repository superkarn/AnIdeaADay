using AIAD.Library.Models;

namespace AIAD.Library.Services.Interfaces
{
    public interface ICrudService<TEntity> where TEntity : BaseWithIdModel
    {
        int Create(ApplicationContext context, TEntity item);
        void DeleteById(ApplicationContext context, int id);
        TEntity GetById(ApplicationContext context, int id);
        void Update(ApplicationContext context, TEntity item);
    }
}
