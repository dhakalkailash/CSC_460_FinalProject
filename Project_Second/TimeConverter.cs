using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
namespace Project_Second
{
	public class TimeConverter : IValueConverter

	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string s = value.ToString();
			if (s != null && s != "")
			{
				DateTime d = DateTime.Parse(s);
				return d.ToString("t");

			}
			else
			{
				return "NA";
			}

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
