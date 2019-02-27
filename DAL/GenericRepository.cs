using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class GenericRepository<T> : IDisposable where T : AbstractIdentifiable
    {
        protected Context context;

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public Task<List<T>> GetAll()
        {
            return context.Set<T>().ToListAsync();
        }

        public Task<int> Update(T t)
        {
            context.Entry(t).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public Task<int> Add(T t)
        {
            context.Set<T>().Add(t);
            return context.SaveChangesAsync();
        }

        public Task<int> Delete(T t)
        {
            context.Set<T>().Remove(t);
            return context.SaveChangesAsync();
        }

        public Task<int> Delete(int id)
        {
            context.Set<T>().Remove(GetById(id));
            return context.SaveChangesAsync();
        }

        public T Where(Func<T, bool> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public List<T> WhereAll(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}