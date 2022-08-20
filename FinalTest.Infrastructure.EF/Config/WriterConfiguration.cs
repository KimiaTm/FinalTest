using FinalTest.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalTest.Infrastructure.EF.Config
{
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.HasKey(a => a.WriterId);
            builder.Property(a => a.WriterName).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(a => a.BirthDayDate).HasColumnType("DateTime").IsRequired();
            builder.Property(a => a.WriterPicture).HasColumnType("nvarchar(400)").IsRequired();
            builder.HasMany(a => a.Book);

        }
    }
}
