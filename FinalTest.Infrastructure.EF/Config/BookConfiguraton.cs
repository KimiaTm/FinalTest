using FinalTest.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.Infrastructure.EF.Config
{

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(a => a.BookId);
            builder.Property(a => a.BookName).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(a => a.Price).HasColumnType("int").IsRequired();
            builder.Property(a => a.Category).HasColumnType("nvarchar(50)").IsRequired();
            builder.HasOne(a => a.writer).WithMany().HasForeignKey(a => a.WriterId);

        }
    }
}
