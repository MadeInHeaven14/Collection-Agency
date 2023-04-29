using CollectionAgency.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAgency
{
    internal class ClientService
    {
        public static string FIO = string.Empty;
        public static string Address = string.Empty;

        public static void ReturnClient(Client client)
        {
            FIO = client.FIO;
            Address = client.Address;
            return;
        }
    }
}
