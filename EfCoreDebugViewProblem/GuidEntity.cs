using System;

namespace EfCoreDebugViewProblem
{
    public class GuidEntity
    {
        public Guid Id { get; set; }
        public OwnedEntity OwnedEntity { get; set; } = null!;
    }
}