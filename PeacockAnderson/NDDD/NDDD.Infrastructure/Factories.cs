
using NDDD.Domain;
using NDDD.Domain.Repositories;
using NDDD.Infrastructure.Fake;
using NDDD.Infrastructure.SqlServer;

namespace NDDD.Infrastructure {

    /// <summary>
    /// Factoryパターン
    /// システム全体にてインスタンスを生成する箇所を集約する
    /// </summary>
    public static class Factories {

        /// <summary>
        /// 計測りぽじとりーの生成する
        /// SqlServerかFakeか切り替える
        /// </summary>
        /// <returns>計測リポジトリー</returns>
        public static IMeasureRepository CreateMeasure() {

// デバッグビルドのみFakeの選択が可能
#if DEBUG
            if (Shared.IsFake) {
                return new MeasureFake();
            }
#endif
            return new MeasureSqlServer();

        }
    }
}
