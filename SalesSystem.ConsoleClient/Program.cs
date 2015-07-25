using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SalesSystem.Data;
using SalesSystem.Model;

//for testing only
namespace SalesSystem.ConsoleClient
    {
    class Program
        {
        static void Main(string[] args)
        {
            var context = new SalesSystemContext();
            var supp = context.Supermarkets.Select(spp => new
            {
                spp.Name,
                spp.Sales
            });
            foreach (var s in supp)
            {
                Console.WriteLine("Supermarket:" + s.Name);
                foreach (var sale in s.Sales)
                {
                    Console.WriteLine("Sale: Id: {0}, ProductId: {1}", sale.Id, sale.ProductId);
                }
            }

        }
        }
    }
