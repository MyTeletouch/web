﻿using MyTeletouch.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected IDbSet<TEntity> dbSet { get; set; }
        protected DbContext Context { get; set; }

        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.dbSet = this.Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetEntities()
        {
            var entities = this.dbSet.AsQueryable();

            return entities;
        }

        public virtual IEnumerable<TEntity> GetEntities(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity != null)
            {
                dbSet.Add(entity);
                this.Context.SaveChanges();
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (entityToUpdate != null)
            {
                dbSet.Attach(entityToUpdate);
                Context.Entry(entityToUpdate).State = EntityState.Modified;
                this.Context.SaveChanges();
            }
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);

            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);

            Context.SaveChanges();
        }

        public virtual void Detach(TEntity entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        /// <summary>
        /// Take records from <see cref="IEnumerable{T}"/> collection by <paramref name="maximClientMessagesPerPage"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="page">Which is current page</param>
        /// <param name="maximRecordsPerPage">How many records show to be taked.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> PaginateRecords(IEnumerable<TEntity> entities, int page, int maximRecordsPerPage)
        {
            int skip = maximRecordsPerPage * (page - 1);
            var paginationEntities = entities.Skip(skip).Take(maximRecordsPerPage);

            return paginationEntities;
        }
    }
}
