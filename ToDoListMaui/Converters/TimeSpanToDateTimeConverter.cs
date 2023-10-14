using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListMaui.Converters
{
    internal class TimeSpanToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not TimeSpan span) return "Nessuna data disponibile";
            var date = new DateTime(1970,1,1,0,0,0,0, DateTimeKind.Utc);
            var result = date + span;
            return result.ToString("dd/MM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
