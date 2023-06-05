using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace XClaim.Web.Server.Converters;

public class CollectionValueComparer<T> : ValueComparer<ICollection<T>> {
    public CollectionValueComparer() : base((c1, c2) => c1!.SequenceEqual(c2!),
        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v!.GetHashCode())), c => (ICollection<T>) c.ToHashSet())
    {
    }
}