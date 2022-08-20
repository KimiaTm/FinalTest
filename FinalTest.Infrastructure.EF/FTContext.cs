using FinalTest.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

namespace FinalTest.Infrastructure.EF
{
    public class FTContext : DbContext
    {
        public FTContext(DbContextOptions<FTContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries().ToList();
            foreach (var item in entries)
            {
                Logs logs = new Logs()
                {
                    Operation = item.State.ToString(),
                    TableName = item.Entity.ToString(),
                    Data = JsonConvert.SerializeObject(item.Entity)
                };
                Logs.Add(logs);
            }
            return base.SaveChanges();
        }
    }
}
