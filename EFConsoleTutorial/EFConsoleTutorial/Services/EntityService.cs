using EFConsoleTutorial.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace EFConsoleTutorial.Services
{
    public class EntityService<T> where T : BaseEntity
    {
        private readonly DataContext dataContext;
        protected readonly DbSet<T> dbSet;

        public EntityService()
        {
            dataContext = new DataContext();
            dbSet = dataContext.Set<T>();
        }

        public IEnumerable<T> GetAllOrN()
        {
            return dbSet.AsEnumerable<T>();
        }

        public IEnumerable<T> GetAllOrN(int numberToTake)
        {
            return dbSet.Take(numberToTake).AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, bool asNoTracking)
        {
            return asNoTracking ? dbSet.Where(predicate).AsEnumerable() : dbSet.AsNoTracking().Where(predicate).AsEnumerable();
        }

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null on create");
            }

            dataContext.Add(entity);
            dataContext.SaveChanges();  
        }

        public void CreateRange(IEnumerable<T> entityList)
        {
            if (entityList == null)
            {
                throw new ArgumentNullException("entity is null on create");
            }

            dataContext.AddRange(entityList);
            dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null on update");
            }
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entityList)
        {
            if (entityList == null)
            {
                throw new ArgumentNullException("entity list is null on update");
            }

            foreach (T entity in entityList)
            {
                if (entity != null)
                {
                    dataContext.Entry(entity).State = EntityState.Modified;
                }
            }

            dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity list is null on update");
            }

            dataContext.Remove(entity);
            dataContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entityList)
        {
            if (entityList == null)
            {
                throw new ArgumentNullException("entity list is null on update");
            }

            dataContext.RemoveRange(entityList);
            dataContext.SaveChanges();
        }
    }
}
