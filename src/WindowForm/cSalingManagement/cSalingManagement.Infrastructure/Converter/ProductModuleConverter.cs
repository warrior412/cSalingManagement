using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace cSalingManagement.Infrastructure.Converter
{
    public class ChooseURLToDisplayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string url = "";
            if(values==null || values.Count()==0)
                return null;
            object currentImage = values[0];
            object newImage = values[1];
            if(newImage==null)
            {
                if (currentImage != null)
                    url= currentImage.ToString();
            }
            else
            {
                url= newImage.ToString();
            }
            return new BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
