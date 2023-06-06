using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.Exceptions {

    /// <summary>
    /// Fake例外
    /// 例外発生したExceptionを引数で呼び出しもとに渡すサンプル
    /// </summary>
    public sealed class FakeException:ExceptionBase {

        /// <summary>
        /// コンストラクタ
        /// 第2引数にException
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="exception">元になった例外</param>
        public FakeException(string message,Exception exception)
            :base(message,exception) {

        }

        // ExceptionBaseを使用するとExceptionKindを実装しないとエラーとなる
        // Exceptionの区分を指定する
        // データがない場合はエラーとする
        public override ExceptionKind Kind => ExceptionKind.Error;

    }
}
