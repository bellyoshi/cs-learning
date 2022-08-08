using NDDD.Domain.ValueObjects;
using System;

namespace NDDD.Domain.Entities {

    /// <summary>
    /// 計測エンティティ
    /// Entityモデルクラス
    /// </summary>
    public sealed class MeasureEntity {

        /// <summary>
        /// コンストラクター
        /// DDDでは完全コンストラクターにする（引数に全ての項目を含む）
        /// 値をセットしたら変更はできない
        /// </summary>
        /// <param name="areaId">エリアID</param>
        /// <param name="measureDate">計測日</param>
        /// <param name="measureValue">計測値</param>
        public MeasureEntity(
            int areaId,
            DateTime measureDate,
            float measureValue) {

            // ID
            // 非DDDの考え方
            // AreaId = areaId;
            // DDDの考え方
            // ValueObject化する（クラス）
            AreaId = new AreaId(areaId);

            // MeasureDate = measureDate;
            MeasureDate = new MeasureDate(measureDate);

            // MeasureValue = measureValue;
            MeasureValue = new MeasureValue (measureValue);
        
        }

        // ID
        // 非DDDの考え方
        // public int AreaId { get; }
        // DDDの考え方
        // ValueObject化する（クラス）
        public AreaId AreaId { get; }

        // 計測日
        // 非DDDの考え方
        // public DateTime MeasureDate { get; }
        // DDDの考え方
        // ValueObject化する（クラス）
        public MeasureDate MeasureDate { get; }

        // 計測値
        // 非DDDの考え方
        // public float MeasureValue { get; }
        // DDDの考え方
        // ValueObject化する（クラス）
        public MeasureValue MeasureValue { get; }

    }
}
