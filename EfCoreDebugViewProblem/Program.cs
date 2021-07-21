using System;
using EfRefData;

namespace EfCoreDebugViewProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDb();
            Test();
        }

        static void CreateDb()
        {
            using var ctx = new TestDbContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }

        static void Test()
        {
            using var ctx = new TestDbContext();

            GuidEntity guidEntity = ctx.Set<GuidEntity>().Find(Guid.Parse("305BFC5B-8492-467D-AFAF-408BD36366BD"));
            LongEntity longEntity = ctx.Set<LongEntity>().Find(1L);

            string debugView = ctx.ChangeTracker.DebugView.ShortView;
        }
    }
}
