using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContacts.Common
{
    public static class ImagesHelper
    {
        public static Uri DefaultPhoto { get { return new Uri("pack://application:,,,/Images/person-placeholder.jpg", UriKind.Absolute); } }
    }
}
