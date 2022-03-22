using OnlineShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        void Delete(T entity);
        T Update(T entity);
        T Get(int id);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetAll();
        List<T> Find(Expression<Func<T, bool>> predicate);
    }
}
