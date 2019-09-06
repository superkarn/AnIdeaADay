using AIAD.Library.Data.Data;
using AIAD.Library.Data.Repositories.Interfaces;
using AIAD.Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AIAD.Library.Data.Repositories.EntityFramework.LookUp
{
    public abstract class BaseLookUpRepository<TEntity> : ILookUpRepository<TEntity> where TEntity : BaseLookUpModel
    {
        readonly ApplicationDbContext Context;
        readonly DbSet<TEntity> DbSet;

        public BaseLookUpRepository(ApplicationDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.DbSet;
        }
    }
}
