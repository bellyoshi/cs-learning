namespace NDDD.Domain.ValueObjects {

    /// <summary>
    /// ValueObjec基底抽象クラス
    /// イコール問題の対応
    /// </summary>
    public abstract class ValueObject<T> where T : ValueObject<T> {

        public override bool Equals(object? obj)
        {
            if (obj is not T vo)
            {
                return false;
            }
            return EqualsCore(vo);
        }

        public static bool operator ==(ValueObject<T> vo1,
            ValueObject<T> vo2) {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObject<T> vo1,
           ValueObject<T> vo2) {
            return !Equals(vo1, vo2);
        }

        public override string ToString() {
            return base.ToString()??String.Empty;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        protected abstract bool EqualsCore(T other);
    }
}
