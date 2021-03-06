﻿using AIAD.Library.Data.Repositories.Interfaces;
using AIAD.Library.Data.Data;
using AIAD.Library.Models;

namespace AIAD.Library.Data.Repositories.EntityFramework
{
    public abstract class BaseWithIdRepository<TEntity> : BaseRepository<TEntity>, ICrudRepository<TEntity> where TEntity : BaseWithIdModel, new()
    {
        public BaseWithIdRepository(ApplicationDbContext context)
            : base(context)
        { }

        public virtual int Create(TEntity item)
        {
            this.Context.Add(item);
            this.Context.SaveChanges();

            return item.Id;
        }

        public virtual void Delete(TEntity item)
        {
            this.Context.Remove(item);
            this.Context.SaveChanges();
        }

        public virtual void DeleteById(int id)
        {
            this.Context.Remove(new TEntity() { Id = id });
            this.Context.SaveChanges();
        }

        public virtual TEntity GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Update(TEntity item)
        {
            var entity = this.Context.Find(item.GetType(), item.Id);

            this.Context.Entry(entity).CurrentValues.SetValues(item);
            this.Context.SaveChanges();
        }
    }
}
