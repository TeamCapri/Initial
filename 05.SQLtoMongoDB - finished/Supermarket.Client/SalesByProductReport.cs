using System;

namespace Supermarket.Client
{
    internal class SalesByProductReport
    {
        private decimal totalIncomes;
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string vendor_name { get; set; }
        public int total_quantity_sold { get; set; }
        public decimal total_incomes 
        {
            get { return Math.Round(this.totalIncomes, 2);}
            set { this.totalIncomes = value; } 
        }
    }
}
