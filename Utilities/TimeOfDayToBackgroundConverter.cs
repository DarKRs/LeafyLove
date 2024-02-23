using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LeafyLove.Utilities
{
    public class TimeOfDayToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var now = DateTime.Now;

            if (now.Hour >= 6 && now.Hour < 12)
                return "pack://application:,,,/LeafyLove;component/Resources/Backgrounds/Morning.png"; // Путь к изображению для утра
            else if (now.Hour >= 12 && now.Hour < 19)
                return "pack://application:,,,/LeafyLove;component/Resources/Backgrounds/Day.png"; // Путь к изображению для дня
            else
                return "pack://application:,,,/LeafyLove;component/Resources/Backgrounds/Night.png";  // Путь к изображению для вечера
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
