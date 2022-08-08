using System;

/// <summary>
/// 例外処理
/// </summary>
namespace NDDD.Domain.Exceptions {
    /// <summary>
    /// データが無かった時の例外
    /// </summary>
    public sealed class DataNotExistsException:ExceptionBase {

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DataNotExistsException() 
            :base("データがありません"){

        }

        // ExceptionBaseを使用するとExceptionKindを実装しないとエラーとなる
        // Exceptionの区分を指定する
        // データがなかった場合、警告とする
        public override ExceptionKind Kind => ExceptionKind.Info;
    }
}
