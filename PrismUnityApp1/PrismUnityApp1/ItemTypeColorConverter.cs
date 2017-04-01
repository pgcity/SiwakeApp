using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SiwakeApp
{
    public class ItemTypeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value as SiwakeKamokuViewModel.ItemType?;
            if(type != null)
            {
                switch (type)
                {
                    case SiwakeKamokuViewModel.ItemType.Add:
                        return Color.Red;
                    case SiwakeKamokuViewModel.ItemType.Correct:
                        return Color.Black;
                    case SiwakeKamokuViewModel.ItemType.Wrong:
                        return Color.Blue;
                }
            }
            return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value as SiwakeKamokuViewModel.ItemType?;
            if (type != null)
            {
                switch (type)
                {
                    case SiwakeKamokuViewModel.ItemType.Add:
                        return Color.Red;
                    case SiwakeKamokuViewModel.ItemType.Correct:
                        return Color.Black;
                    case SiwakeKamokuViewModel.ItemType.Wrong:
                        return Color.Blue;
                }
            }
            return Color.Black;
        }
    }
}
