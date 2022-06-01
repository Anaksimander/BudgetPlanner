using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace BudgetPlanner.Converters
{
    public class ConverterDecimal : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is decimal))
                return DependencyProperty.UnsetValue;

            string str = ((decimal)value).ToString();

            return ((decimal)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (!(value is string) )
                return DependencyProperty.UnsetValue;

            if ((string)value == "")
                return null;

            if (decimal.TryParse((string)value, out decimal number) && number >= 0)
            {
                return decimal.Parse(((string)value));
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
