namespace EfCoreDebugViewProblem
{
    public class LongEntity
    {
        public long Id { get; set; }
        public OwnedEntity OwnedEntity { get; set; } = null!;
    }
}