using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace cSalingManagement.Infrastructure.Converter
{

    public class IsReadyToEnabledConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            if (bool.Parse(value.ToString()))
                return false;
            else
                return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class IsReadyToWidthConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(parameter==null)
            {

            }
            else
            {
                if (parameter.ToString().Equals("ButtonEdit"))
                {
                    if (value == null || !bool.Parse(value.ToString()))
                    {
                        return null;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (parameter.ToString().Equals("ButtonSaved"))
                {
                    if (value == null || !bool.Parse(value.ToString()))
                    {
                        return 0;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
