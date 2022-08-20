using FinalTest.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalTest.Infrastructure.EF.Config
{
    public class LogsConfiguration : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.TableName);
            builder.Property(a => a.Operation);
            builder.Property(a => a.Data);
            builder.Property(a => a.InsertDate).HasColumnType("datetime").IsRequired();

        }
    }
}
