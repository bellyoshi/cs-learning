using NDDD.Domain.ValueObjects;


namespace NDDD.Infrastructure.Fake
{
    public class FakeValueObject : ValueObject
    {
        int Value { get; }
        public FakeValueObject(int value)
        {
            this.Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
    
}
