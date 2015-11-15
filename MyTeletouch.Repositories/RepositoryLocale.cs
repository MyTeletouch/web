using MyTeletouch.Entities;
using MyTeletouch.Repositories.Intefraces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace MyTeletouch.Repositories
{
    public class RepositoryLocale<TEntity> : Repository<TEntity>, IRepositoryLocale<TEntity> where TEntity : BaseModel
    {
        public RepositoryLocale(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// See documentation of <seealso cref="IRepositoryLocale{TEntity}.AddOrUpdateRecord(TEntity, Expression{Func{TEntity, bool}})"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="expression"></param>
        public void AddOrUpdateRecord(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            TEntity localEntity = dbSet.FirstOrDefault(expression);

            if (localEntity == null)
            {
                this.Insert(localEntity);
            }
            else
            {
                this.Update(localEntity);
            }
        }
    }
}