using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Knijniymagazin.Controller
{
    internal class ConnectionString
    {
        public static string ConnStr {
            get {
                return ConfigurationManager.ConnectionStrings["Knijniymagazin.Properties.Settings.ConnStr"].ConnectionString;
            }
        }
    }
}
