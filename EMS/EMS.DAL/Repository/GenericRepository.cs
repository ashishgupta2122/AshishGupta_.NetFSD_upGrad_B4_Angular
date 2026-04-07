using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using EMS.DAL.Data;

namespace EMS.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EMSDbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(EMSDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        // 🔥 FIXED (Fresh data always)
        public IEnumerable<T> GetAll()
        {
            return _table.AsNoTracking().ToList();
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Update(obj);
        }

        public void Delete(object id)
        {
            var entity = _table.Find(id);
            if (entity != null)
                _table.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}