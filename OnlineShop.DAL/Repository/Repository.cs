using OnlineShop.DAL.Data;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T Get(int id) => _context.Set<T>().FirstOrDefault(e => e.Id == id)!;

        public T Get(Expression<Func<T, bool>> predicate) => _context.Set<T>().Where(predicate).FirstOrDefault()!;

        public List<T> GetAll() => _context.Set<T>().ToList();

        public T Update(T entity)
        {
            _context.SaveChanges();
            return entity;
        }
    }
}
