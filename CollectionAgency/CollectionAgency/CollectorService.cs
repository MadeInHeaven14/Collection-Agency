using CollectionAgency.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAgency
{
    internal class CollectorService
    {
        public static string FIO = string.Empty;
        public static string Login = string.Empty;
        public static string Password = string.Empty;

        public static void ReturnCollector(Collector collector)
        {
            FIO = collector.FIO;
            Login = collector.Login;
            Password = collector.Password;
            return;
        }
    }
}
