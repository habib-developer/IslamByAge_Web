using IslamByAge.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IslamByAge.Core.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        public T GetById(object id);
        public IQueryable<T> All();
        public T Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
