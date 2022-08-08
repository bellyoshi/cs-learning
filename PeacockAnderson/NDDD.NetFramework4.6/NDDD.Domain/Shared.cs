using System.Configuration;

namespace NDDD.Domain {

    /// <summary>
    /// 共通の変数
    /// </summary>
    public static class Shared {

        /// <summary>
        /// SqlServerかFakeか分かるようにする
        /// ここでSqlかFakeか切り替える
        /// 設定ファイルから読む
        /// </summary>
        public static bool IsFake { get; } =
            ConfigurationManager.AppSettings["IsFake"] == "1";


        /// <summary>
        /// Fakeファイルのパス
        /// </summary>
        public static string FakePath { get; } =
            ConfigurationManager.AppSettings["FakePath"];


        /// <summary>
        /// ログインID
        /// </summary>
        public static string LoginId { get; set; } = string.Empty;


    }
}

