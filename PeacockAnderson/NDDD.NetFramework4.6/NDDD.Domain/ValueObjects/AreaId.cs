using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ValueObject
/// </summary>
namespace NDDD.Domain.ValueObjects {

    /// <summary>
    /// AreaIdのValueObject
    /// 完全コンストラクタパターン
    /// コンストラクタで値を設定後は、値を変更できないようにする
    /// AreaIdに関する処理はすべてここに書く
    /// 問題
    /// クラスは参照型なので、同じ値で比較してイコールにならない（アドレス比較のため）
    /// 解決のためValueObject基底抽象クラスを継承してEqualsCoreを実装する
    /// </summary>
    public sealed class AreaId:ValueObject<AreaId> {
       
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public AreaId(int value) {
            Value = value;
        }
        // getのみ
        public int Value { get; }

        /// <summary>
        /// イコールイコール問題解消
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool EqualsCore(AreaId other) {
            return this.Value == other.Value;
        }

        // 表示する項目
        // ビジネスロジック処理があればここに書く
        // この例は、表示の制御（4桁表示）
        public string DisplayValue => Value.ToString().PadLeft(3, '0');


    }
}
