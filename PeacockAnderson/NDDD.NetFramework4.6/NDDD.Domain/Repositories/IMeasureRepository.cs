using NDDD.Domain.Entities;
using System.Collections.Generic;

/// <summary>
/// リポジトリー
/// </summary>
namespace NDDD.Domain.Repositories {

    /// <summary>
    /// 計測リポジトリー
    /// </summary>
    public interface IMeasureRepository {

        // 直近値の取得
        MeasureEntity GetLatest();

        // エリアごとの直近値を取得
        IReadOnlyList<MeasureEntity> GetLatests();

    }
}
