namespace EfCoreDebugViewProblem
{
    public class LongEntity
    {
        public long Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not LongEntity other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == default || other.Id == default)
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(LongEntity? a, LongEntity? b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(LongEntity? a, LongEntity? b) => !(a == b);
        public override int GetHashCode() => (GetType() + Id.ToString()).GetHashCode();
    }
}