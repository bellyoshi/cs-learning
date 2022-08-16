using NDDD.Domain.ValueObjects;


namespace NDDD.Infrastructure.Fake
{
    public class FakeValueObject : ValueObject<FakeValueObject>
    {
        int Value { get; }
        public FakeValueObject(int value)
        {
            this.Value = value;
        }

        protected override bool EqualsCore(FakeValueObject other)
        {
            return this.Value == other.Value;
        }
    }
    
}
