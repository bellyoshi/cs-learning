using NDDD.Domain.StaticValues;
using NDDD.Infrastructure;
using System.Threading;

/// <summary>
/// タイマー処理を一元化する
/// </summary>
namespace NDDD.WinForm.BackgroundWorkers {

    /// <summary>
    /// 直近値のタイマー処理
    /// </summary>
    internal static class LatestTimer {

        /// <summary>
        /// タイマー
        /// </summary>
        private static Timer _timer;

        /// <summary>
        /// 処理の時はTrue
        /// </summary>        
        private static bool _isWork=false;

        /// <summary>
        /// コンストラクター
        /// </summary>
        static LatestTimer() {
            _timer = new Timer(Callback);
        }

        /// <summary>
        /// Start
        /// </summary>
        internal static void Start() {
            _timer.Change(0, 10000);
        }

        /// <summary>
        /// Stop
        /// </summary>
        internal static void Stop() {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Callback関数
        /// </summary>
        /// <param name="o"></param>
        private static void Callback(object o) {
            if (_isWork) {
                return;
            }

            try {
                _isWork = true;
                // timerの処理
                // サンプルとして定期的に計測結果を更新する
                Measures.Create(Factories.CreateMeasure());

            }
            finally{
                _isWork = false;
            }
        }
    }
}
