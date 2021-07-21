using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCoreDebugViewProblem
{
    public class TestDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=127.0.0.1,5433;Initial Catalog=DebugViewProblem;User Id=sa;Password=Pass@word")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuidEntity>(b =>
            {
                b.HasData(new List<GuidEntity> {new GuidEntity {Id = Guid.Parse("305BFC5B-8492-467D-AFAF-408BD36366BD")}});
                b.OwnsOne(x => x.OwnedEntity).HasData(new List<object>
                {
                    new {GuidEntityId = Guid.Parse("305BFC5B-8492-467D-AFAF-408BD36366BD"), Nothing = string.Empty}
                });
            });
            modelBuilder.Entity<LongEntity>(b =>
            {
                b.HasData(new List<LongEntity> {new LongEntity {Id = 1}});

                b.OwnsOne(x => x.OwnedEntity).HasData(new List<object>
                {
                    new {LongEntityId = 1L, Nothing = string.Empty}
                });
            });
        }
    }
}