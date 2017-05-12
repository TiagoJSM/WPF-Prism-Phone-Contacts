using PhoneContacts.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PhoneContacts.Header
{
    [ValueConversion(typeof(Menu), typeof(bool))]
    public class HeaderMenuConverter : EnumBooleanConverter
    {
    }
}
