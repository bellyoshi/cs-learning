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
            var vo = obj as T;
            if (vo == null) {
                return false;
            }
            return EqualsCore(vo);
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
            return base.ToString();
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
