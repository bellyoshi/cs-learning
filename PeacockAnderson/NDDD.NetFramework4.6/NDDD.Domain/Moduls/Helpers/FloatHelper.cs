using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 共通関数的な機能を集約する
/// </summary>
namespace NDDD.Domain.Helpers {
    
    /// <summary>
    /// Floatヘルパー
    /// </summary>
    public static class FloatHelper {
    
        /// <summary>
        /// 少数点以下の桁数を0埋めする
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="decimalPoint">小数点以下桁数</param>
        /// <returns></returns>
        public static string RoundString(
            this float value,
            int decimalPoint) {

            value = Convert.ToSingle(Math.Round(value, decimalPoint));

            return value.ToString(
                decimalPoint == 0 ?
                string.Empty : "." +
                string.Concat(Enumerable.Repeat("0", decimalPoint)));
        }
    }
}
