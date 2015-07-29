using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLtoMYSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new supermarket_chainEntities();
            Console.WriteLine(db.vendors.Count());
        }
    }
}
