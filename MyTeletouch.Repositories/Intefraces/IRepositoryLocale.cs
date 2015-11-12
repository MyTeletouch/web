using MyTeletouch.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Repositories.Intefraces
{
    interface IRepositoryLocale<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Try to find information for entity by lambda expression <seealso cref="System.Linq.Expressions.Expression"/>.
        /// Example for lambda expresion: .FirstOrDefault(c => c.CountryId ==5 && c.Locale.Equals("en"))
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="source"></param>
        void AddOrUpdateRecord(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, bool>> expression);
    }
}
