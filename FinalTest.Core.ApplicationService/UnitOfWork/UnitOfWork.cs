using FinalTest.Core.Contract.Repository;
using FinalTest.Core.Contract.UnitOfWork;
using FinalTest.Infrastructure.Data;
using FinalTest.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.Core.ApplicationService.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FTContext context;

        public UnitOfWork(FTContext context)
        {
            this.context = context;
            Book=new BookRepository(this.context);
            Writer=new WriterRepository(this.context);
        }

        public IBookRepository Book { get; private set; }

        public IWriterRepository Writer { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int save()
        {
            return context.SaveChanges();
        }
    }
}
