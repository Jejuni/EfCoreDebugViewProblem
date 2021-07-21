using System;
using System.Collections.Generic;
using EfCoreDebugViewProblem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfRefData
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
            modelBuilder.Entity<GuidEntity>().HasData(new List<GuidEntity> {new GuidEntity {Id = Guid.Parse("305BFC5B-8492-467D-AFAF-408BD36366BD")}});
            modelBuilder.Entity<LongEntity>().HasData(new List<LongEntity> {new LongEntity {Id = 1}});
            modelBuilder.Entity<OtherLongEntity>().HasData(new List<OtherLongEntity> {new OtherLongEntity { Id = 1}});
        }
    }
}