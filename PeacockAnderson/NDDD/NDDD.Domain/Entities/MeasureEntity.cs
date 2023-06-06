using NDDD.Domain.ValueObjects;


namespace NDDD.Domain.Entities; 
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
        float measureValue) 
    {
        AreaId = new AreaId(areaId);
        MeasureDate = new MeasureDate(measureDate);
        MeasureValue = new MeasureValue (measureValue);
    }

    public AreaId AreaId { get; }
    public MeasureDate MeasureDate { get; }
    public MeasureValue MeasureValue { get; }

}
