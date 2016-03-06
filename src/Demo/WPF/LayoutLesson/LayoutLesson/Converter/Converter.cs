using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace LayoutLesson.Converter
{
   
    public class YesNoToNoYesConverter : IValueConverter
    {

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (bool.Parse(value.ToString()))
                return false;
            return true;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            throw new NotImplementedException();
        }
    }

    public class ValueToBackgroundConverter : IMultiValueConverter
    {


        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = null;
            bool willCheck = bool.Parse(values[0].ToString());
            float value = float.Parse(values[1].ToString());
            Class.InfoStatus status = (Class.InfoStatus)Enum.Parse(typeof(Class.InfoStatus), values[2].ToString());
            if (!willCheck)
            {
                brush = new SolidColorBrush(Colors.Gray);
            }
            else if ((float.Parse(value.ToString()) < 50 || float.Parse(value.ToString()) > 150)&&status!=Class.InfoStatus.RESOVLED)
            {
                brush = new SolidColorBrush(Colors.Red);
            }
            return brush;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ValueToForeGroundConverter : IMultiValueConverter
    {


        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float value = float.Parse(values[0].ToString());
            Class.InfoStatus status = (Class.InfoStatus)Enum.Parse(typeof(Class.InfoStatus), values[1].ToString());
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF57024"));
            if ((float.Parse(value.ToString()) < 50 || float.Parse(value.ToString()) > 150)&&status == Class.InfoStatus.WARNING)
            {
                brush = new SolidColorBrush(Colors.White);
            }
            return brush;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ConvertCheckResult : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (float.Parse(value.ToString()) == 0)
            {
                if (parameter!=null)
                    return "";
                return "-";
            }
            return float.Parse(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ConvertMultiParameter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
