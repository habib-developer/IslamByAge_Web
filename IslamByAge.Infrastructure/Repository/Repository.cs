using IslamByAge.Core.Domain;
using IslamByAge.Core.Interfaces;
using IslamByAge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IslamByAge.Infrastructure.Repository
{
    public class Repository<T>:IRepository<T> where T:BaseEntity
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public T Add(T entity)
        {
            context.Add<T>(entity);
            context.SaveChanges();
            return entity;
        }
        public IQueryable<T> All()
        {
            return context.Set<T>().AsQueryable<T>();
        }
        public void Delete(T entity)
        {
            context.Remove<T>(entity);
            context.SaveChanges();
        }


        public T GetById(object id)
        {
            return context.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            context.Update<T>(entity);
            context.SaveChanges();
        }
    }
}
