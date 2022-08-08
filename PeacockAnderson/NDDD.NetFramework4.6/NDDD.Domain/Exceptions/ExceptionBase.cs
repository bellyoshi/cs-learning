using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain.Exceptions {

    /// <summary>
    /// 例外抽象基底クラス
    /// このクラスを継承することで例外の区分を設定する
    /// </summary>
    public abstract class ExceptionBase : Exception {

        /// <summary>
        /// コンストラクタ（引数に例外なし）
        /// </summary>
        /// <param name="message">メッセージ</param>
        public ExceptionBase(string message):base(message) {

        }

        /// <summary>
        /// コンストラクタ（引数に例外あり）
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="exception">元になった例外</param>
        public ExceptionBase(string message, Exception exception)
            : base(message, exception) { 

        }

        // ExceptionKind実装しないとコンパイルが通らない
        // Exceptionの区分を指定する
        public abstract ExceptionKind Kind { get; }

        /// <summary>
        /// 例外区分
        /// </summary>
        public enum ExceptionKind {
            Info,
            Warning,
            Error
        }
    }
}
