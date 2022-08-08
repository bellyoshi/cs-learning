using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using NDDD.Domain.ValueObjects;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 値を保存する
/// コレクションとか変数とか
/// </summary>
namespace NDDD.Domain.StaticValues {

    /// <summary>
    /// エリアごとの直近値のリスト
    /// </summary>
    public static class Measures {

        // リストをもつ
        // リスはひとつだけ
        private static List<MeasureEntity> _entities = new List<MeasureEntity>();


        /// <summary>
        /// リストを作成する
        /// </summary>
        /// <param name="repository">計測リポジトリー</param>
        public static void Create(IMeasureRepository repository) {
            
            // publicになっているので複数からアクセスされる可能性がある
            // 一つだけのアクセスlockで保証する
            lock (((ICollection)_entities).SyncRoot) {
                _entities.Clear();
                // リストを取得
                _entities.AddRange(repository.GetLatests());
            }
        }


        /// <summary>
        /// リストに追加する
        /// </summary>
        /// <param name="entity">計測リポジトリー</param>
        public static void Add(MeasureEntity entity) {
            
            // ここも一つだけアクセスの保証を行う
            lock (((ICollection)_entities).SyncRoot) {
                _entities.Add(entity);
            }
        }


        /// <summary>
        /// リストを使えるようにメソッドを公開する
        /// AreaIdを検索して結果を返す
        /// </summary>
        /// <param name="areaId">エリアId</param>
        /// <returns></returns>
        public static MeasureEntity GetLatest(AreaId areaId) {
            
            // ここも一つだけアクセスの保証を行う
            lock (((ICollection)_entities).SyncRoot) {
                return _entities.Find(x => x.AreaId == areaId);
            }
        }
    }
}
