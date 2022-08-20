using FinalTest.Core.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.Core.Contract.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IBookRepository Book { get; }
        public IWriterRepository Writer { get; }
        int save();
    }
}
