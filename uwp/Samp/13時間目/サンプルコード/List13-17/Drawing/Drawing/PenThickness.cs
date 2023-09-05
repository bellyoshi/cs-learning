using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    public enum PenThicknessEnum
    {
        Undefined,
        Thin = 1,
        Bold
    }

    class PenThickness : Windows.UI.Xaml.Data.IValueConverter
    {
        // ConverterParameterをEnumに変換するメソッド
        private PenThicknessEnum ConvertFromConverterParameter(object parameter)
        {
            string parameterString = parameter as string;
            return (PenThicknessEnum)Enum.Parse(typeof(PenThicknessEnum), parameterString);
        }

        // Enum → bool
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // XAMLに定義されたConverterParameterをEnumに変換する
            PenThicknessEnum parameterValue = ConvertFromConverterParameter(parameter);

            // ConverterParameterとバインディングソースの値が等しいか？
            return parameterValue.Equals(value);
        }

        // bool → Enum
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // true→falseの変化は無視する
            // ※こうすることで、選択されたラジオボタンだけをデータに反映させる
            if (!(bool)value)
                return Windows.UI.Xaml.DependencyProperty.UnsetValue;

            // ConverterParameterをEnumに変換して返す
            return ConvertFromConverterParameter(parameter);
        }
    }
}
