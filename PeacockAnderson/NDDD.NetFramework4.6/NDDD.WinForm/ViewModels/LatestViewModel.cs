using NDDD.Domain.Entities;
using NDDD.Domain.Exceptions;
using NDDD.Domain.Repositories;
using NDDD.Domain.StaticValues;
using NDDD.Domain.ValueObjects;
using NDDD.Infrastructure;
using System;
using System.Transactions;

namespace NDDD.WinForm.ViewModels {

    /// <summary>
    /// 直近値のViewModel
    /// ①インターフェースの場合
    /// ②具象クラスの場合（ロジックを実装したい場合）
    /// </summary>
    public class LatestViewModel : ViewModelBase {

        // ①インターフェイスを使う場合
        private IMeasureRepository _measureRepository;
        // ②具象クラスを使う場合
        //private MeasureRepository _measureRepository;


        // private MeasureEntity _measure;

        /// <summary>
        /// エリアId
        /// </summary>
        private string _areaIdText = string.Empty;
        
        /// <summary>
        /// 計測日
        /// </summary>
        private string _measureDateText = string.Empty;

        /// <summary>
        /// 計測値
        /// </summary>
        private string _measureValueText = string.Empty;

        /// <summary>
        /// コンストラクター
        /// 何も指定されていないときは
        /// Factoriesを通じてインスタンスを生成する
        /// </summary>
        public LatestViewModel()
            : this(Factories.CreateMeasure()) { 
        }

        /// <summary>
        /// コンストラクター
        /// 引数が指定されている
        /// 指定されたRepositoriesを参照する
        /// </summary>
        /// <param name="measureRepository"></param>
        public LatestViewModel(IMeasureRepository measureRepository) {
            // ①共通のインスタンス（インターフェースの場合）
            _measureRepository = measureRepository;
            // ②共通のインスタンス（具象クラスの場合）
            //_measureRepository = new MeasureRepository(measureRepository);
        }

        /// <summary>
        /// エリアId
        /// </summary>
        public string AreaIdText {
            get {
                return _areaIdText;
            }
            set {
                // View側に通知する
                SetProperty(ref _areaIdText, value);
            }
        }

        /// <summary>
        /// 計測日
        /// </summary>
        public string MeasureDateText {
            get {
                return _measureDateText;
            }
            set {
                // View側に通知する
                SetProperty(ref _measureDateText, value);
            }


        }

        /// <summary>
        /// 計測値
        /// </summary>
        public string MeasureValueText {
            get {
                return _measureValueText;
            }
            set {
                // View側に通知する
                SetProperty(ref _measureValueText, value);
            }
        }

        /// <summary>
        /// サーチ処理
        /// </summary>
        public void Search() {

            // ①インターフェース
            var measure = _measureRepository.GetLatest();
            // ②具象クラス
            //var measure = Measures.GetLatest( new AreaId(10));
           
            // データが無ければ例外
            if (measure == null) {
                throw new DataNotExistsException();
            }

            // AreaIdText = measure.AreaId.ToString().PadLeft(4, '0');
            // ValueObject化
            // Objectを指定
            AreaIdText = measure.AreaId.DisplayValue;

            // MeasureDateText = measure.MeasureDate.ToString("yyyy/MM/dd HH:mm:ss");
            MeasureDateText = measure.MeasureDate.DisplayValue;

            // MeasureValueText = Math.Round(measure.MeasureValue, 2) + "℃";
            MeasureValueText = measure.MeasureValue.DisplayValue;

        }


        /// <summary>
        /// 保存処理
        /// DBへ更新処理
        /// トランザクションを行う
        /// </summary>
        public void Save() {

            // トランザクション
            // System.Transactionsを使用しViewModelにてトランザクションを制御する
            using (var scope = new TransactionScope()) {
                // ヘッダー取得
                // 明細取得
                // 在庫更新
                // 履歴更新
                // 顧客情報更新

                scope.Complete();
            }
        }
    }
}
