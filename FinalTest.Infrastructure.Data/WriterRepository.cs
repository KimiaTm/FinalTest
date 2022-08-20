using FinalTest.Core.Contract.Repository;
using FinalTest.Core.Domain.Entities;
using FinalTest.Infrastructure.Data.Common;
using FinalTest.Infrastructure.EF;

namespace FinalTest.Infrastructure.Data
{
    public class WriterRepository : GenericRepository<Writer>, IWriterRepository
    {
        public WriterRepository(FTContext context) : base(context)
        {
        }
    }
}
