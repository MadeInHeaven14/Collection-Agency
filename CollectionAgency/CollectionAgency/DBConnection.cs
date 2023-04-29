using CollectionAgency.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAgency
{
    internal class DBConnection
    {
        public static CollectionAgencyEntities5 connection = new CollectionAgencyEntities5();
    }
}
