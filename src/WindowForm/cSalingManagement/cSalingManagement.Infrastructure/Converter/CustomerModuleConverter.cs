using cSalingManagement.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace cSalingManagement.Infrastructure.Converter
{
    public class DisplayMultiPhoneNumberConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values == null || values.Count() <= 0)
                return null;
            string phone1 = values[0]==null?"": values[0].ToString();
            string phone2 = values[1] == null ? "" : values[1].ToString();
            return phone1 + Environment.NewLine + phone2;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class FullCustomerAddressConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values == null || values.Count() <= 0)
                return null;
            string address = values[0] == null ? "" : values[0].ToString();
            string ward = values[1] == null ? "" : values[1].ToString();
            string district = values[2] == null ? "" : values[2].ToString();
            string city = values[3] == null ? "" : values[3].ToString();
            ObservableCollection<M_Ward> lstWard = values[4] == null ? null : values[4] as ObservableCollection<M_Ward>;
            ObservableCollection<M_District> lstDistrict = values[5]==null?null:values[5] as ObservableCollection<M_District>;
            ObservableCollection<M_City> lstCity = values[6]==null?null :values[6] as ObservableCollection<M_City>;

            if (lstWard == null || lstDistrict == null || lstCity == null)
                return null;
            string rs = address;

            foreach(M_Ward item in lstWard)
            {
                if(item.WardID.Equals(ward))
                {
                    rs+= ", "+item.Ward_Name;
                    break;
                }
            }
            foreach(M_District item in lstDistrict)
            {
                if(item.DistrictID.Equals(district))
                {
                    rs+=", "+item.District_Name;
                    break;
                }
            }
            foreach(M_City item in lstCity)
            {
                if(item.CityID.Equals(city))
                {
                    rs+=", "+item.City_Name;
                    break;
                }
            }
            return rs;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
