using System;

namespace NDDD.Domain.ValueObjects {

    /// <summary>
    /// MesureDateのValueObject
    /// 完全コンストラクタパターン
    /// コンストラクタで値を設定後は、値を変更できないようにする
    /// MesureDateに関する処理はすべてここに書く
    /// 問題
    /// クラスは参照型なので、同じ値で比較してイコールにならない（アドレス比較のため）
    /// 解決のためValueObject基底抽象クラスを継承してEqualsCoreを実装する
    /// </summary>
    public sealed class MeasureDate : ValueObject<MeasureDate> {
       
        /// コンストラクタ 
        public MeasureDate(DateTime value) {
            Value = value;
        }
        
        // getのみ
        public DateTime Value { get; }

        /// <summary>
        /// イコールイコール問題解消
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool EqualsCore(MeasureDate other) {
            return this.Value == other.Value;
        }

        // 表示する項目
        // ビジネスロジック処理があればここに書く
        // この例は、表示の制御（4桁表示）
        public string DisplayValue => Value.ToString("yyyy/MM/dd HH:mm:ss");


    }
}
