using FinalTest.Core.Contract.Repository;

using FinalTest.Core.Domain.Entities;
using FinalTest.Infrastructure.Data.Common;
using FinalTest.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinalTest.Infrastructure.Data
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(FTContext context) : base(context)
        {
        }
    }
}
