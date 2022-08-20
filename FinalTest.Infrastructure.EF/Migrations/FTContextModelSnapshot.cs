﻿// <auto-generated />
using System;
using FinalTest.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalTest.Infrastructure.EF.Migrations
{
    [DbContext(typeof(FTContext))]
    partial class FTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalTest.Core.Domain.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.Property<int?>("WriterId1")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("WriterId");

                    b.HasIndex("WriterId1");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("FinalTest.Core.Domain.Entities.Logs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Operation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("FinalTest.Core.Domain.Entities.Writer", b =>
                {
                    b.Property<int>("WriterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDayDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("WriterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WriterPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("WriterId");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("FinalTest.Core.Domain.Entities.Book", b =>
                {
                    b.HasOne("FinalTest.Core.Domain.Entities.Writer", "writer")
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalTest.Core.Domain.Entities.Writer", null)
                        .WithMany("Book")
                        .HasForeignKey("WriterId1");
                });
#pragma warning restore 612, 618
        }
    }
}
