using NDDD.Domain.Entities;
using NDDD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.Repositories {

    /// <summary>
    /// Repositoryに具象クラスを書きたいとき
    /// 事例としてDBから取ってきた値にビジネスロジックがある場合
    /// Repositoryに書くのも案
    /// </summary>
    public sealed class MeasureRepository {

        // インターフェースを保持
        private IMeasureRepository _repository;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="repository">計測リポジトリー</param>
        public MeasureRepository(IMeasureRepository repository) {
            _repository = repository;
        }

        /// <summary>
        /// 3回の平均というビジネスロジックを追加している
        /// </summary>
        /// <returns></returns>
        public MeasureEntity GetLatest() {
           
            var val1 = _repository.GetLatest();

            // データが無ければ例外
            if(val1 == null) {
                throw new DataNotExistsException();
            }

            System.Threading.Thread.Sleep(10);
            var val2 = _repository.GetLatest();
            System.Threading.Thread.Sleep(10);
            var val3 = _repository.GetLatest();
            System.Threading.Thread.Sleep(10);

            var sum =
                val1.MeasureValue.Value +
                val2.MeasureValue.Value +
                val3.MeasureValue.Value;
            var ave = sum / 3f;

            return new MeasureEntity(
                val3.AreaId.Value,
                val3.MeasureDate.Value,
                ave);

        }
    }
}
