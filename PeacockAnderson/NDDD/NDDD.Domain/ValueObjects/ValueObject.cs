namespace NDDD.Domain.ValueObjects {

    /// <summary>
    /// ValueObjec基底抽象クラス
    /// イコール問題の対応
    /// </summary>
    public abstract class ValueObject<T> where T : ValueObject<T> {

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if(obj is T)
            {
                var vo = (T)obj;
                return EqualsCore(vo);
            } 
            return false;
           
        }

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="vo1"></param>
        /// <param name="vo2"></param>
        /// <returns></returns>
        public static bool operator ==(ValueObject<T> vo1,
            ValueObject<T> vo2) {
            return Equals(vo1, vo2);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="vo1"></param>
        /// <param name="vo2"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObject<T> vo1,
           ValueObject<T> vo2) {
            return !Equals(vo1, vo2);
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected abstract bool EqualsCore(T other);
        public override string ToString() {
            return base.ToString()??String.Empty;
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
