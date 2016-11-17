using cSalingManagement.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
            string imagePath = ConfigurationManager.AppSettings["ImageProductURL"];
            if(values==null || values.Count()==0)
                return null;
            object currentImage = values[0];
            object newImage = values[1];
            if(newImage==null)
            {
                if (currentImage != null)
                    url= imagePath +currentImage.ToString();
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

    public class ProductModule_SupplierToWidth : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null && parameter.ToString().Equals("ShowEditButton"))
            {
                if (value == null || value.ToString().Equals(""))
                    return 0;
                else
                    return null;
            }
            if (value != null && !value.ToString().Equals("") )
            {
                if(parameter==null)
                {
                    return 40;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (parameter == null)
                {
                    return 0;
                }
                else
                {
                    return 40;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ProductModule_IsEditingToWidthConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (parameter == null)
                {
                    if (bool.Parse(value.ToString()))
                        return 0;
                    else
                        return 80;
                }
                else
                {
                    if (bool.Parse(value.ToString()))
                        return 80;
                    else
                        return 0;
                }
            }
            return 80;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ProductModule_SupplierIDToSupplierNameConverter : IMultiValueConverter
    {
                      
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try{
                string supplierID = values[0].ToString();
                ObservableCollection<M_Supplier> arr = values[1] as ObservableCollection<M_Supplier>;
                foreach(M_Supplier item in arr)
                {
                    if (item.SupplierID.Equals(supplierID))
                        return item.SupplierName;
                }
            }catch(Exception ex)
            {
                return "";
            }
            return "";
            
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
