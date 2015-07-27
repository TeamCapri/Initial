using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            using( var kuf = new AdsEntities())
            using( var db = new MSSQLtoMYSQL.supermarket_chainEntities())
            {
                Console.WriteLine(kuf.Ads.Count());
                Console.WriteLine(db.vendors.Count());
            }
        }
    }
}
