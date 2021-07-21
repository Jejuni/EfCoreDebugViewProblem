using System;

namespace EfCoreDebugViewProblem
{
    public class GuidEntity
    {
        public Guid Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not GuidEntity other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == default || other.Id == default)
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(GuidEntity? a, GuidEntity? b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(GuidEntity? a, GuidEntity? b) => !(a == b);
        public override int GetHashCode() => (GetType() + Id.ToString()).GetHashCode();
    }
}