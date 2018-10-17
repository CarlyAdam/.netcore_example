using Lot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lot.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        //IEnumerable<T> GetAll
        IQueryable<T> GetAll();
        T Get(int id);
        IQueryable<T> GetQueryable(int id);
        IQueryable<T> GetQueryable();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}