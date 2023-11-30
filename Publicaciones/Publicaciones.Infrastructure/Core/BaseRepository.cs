using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;

namespace Publicaciones.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PublicacionesContext context;

        private DbSet<TEntity> entitie;

        public BaseRepository(PublicacionesContext context)
        {
                this.context = context;
                this.entitie = context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
           return this.entitie.Any(filter);
        }

        public  virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entitie.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.entitie.ToList();
        }

        public virtual TEntity GetEntityByID(int ID)
        {
            return this.entitie.Find(ID);
        }

        public virtual void Remove(TEntity entity)
        {
            entitie.Remove(entity);
        }

        public virtual void Save(TEntity entity)
        {
            entitie.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            entitie.Update(entity);
        }
    }
}
