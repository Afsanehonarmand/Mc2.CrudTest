
namespace Mc2.CrudTest.Domain.Common
{
    public abstract class ValueObject : IEquatable<ValueObject?>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj!.GetType() != GetType())
            {
                return false;
            }

            ValueObject valueObject = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetEqualityComponents);
        }
    }
}
