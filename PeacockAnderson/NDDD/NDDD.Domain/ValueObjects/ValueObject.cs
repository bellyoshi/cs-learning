namespace NDDD.Domain.ValueObjects {

    /// <summary>
    /// ValueObjec基底抽象クラス
    /// イコール問題の対応
    /// </summary>
    public abstract class ValueObject<T> where T : ValueObject<T> {

        public override bool Equals(object? obj)
            => obj is T vo ? EqualsCore(vo) : false;
        

        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2) 
            => Equals(vo1, vo2);
        

        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2) 
            => !Equals(vo1, vo2);


        //public override string ToString() 
        //    => base.ToString()??String.Empty;


        public override int GetHashCode()
            => base.GetHashCode();


        protected abstract bool EqualsCore(T other);
    }
}
