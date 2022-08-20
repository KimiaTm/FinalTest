using FinalTest.Core.Contract.Repository.Common;
using FinalTest.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FinalTest.Infrastructure.Data.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FTContext context;
        public GenericRepository(FTContext context)
        {
            this.context = context;
        }
       
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
       
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

       
    }
}
