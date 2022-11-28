using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTrackerApp
{
    public class Expense
    {
        private string expenseName;
        private double price;
        private string category;

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                this.price = value;
            }
        }
        public string ExpenseName
        {
            get
            {
                return expenseName;
            }
            set
            {
                this.expenseName = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                this.category = value;
            }
        }

        public Expense(string expenseName, string category, String price)
        {
            this.ExpenseName = expenseName;
            this.Category = category;
            //zadanie 9
            string str = price;
            if (Double.TryParse(str, out double num))
            {
                this.Price = num;
                // .. rest of your code
            }
        }

        public Expense(string expenseName, string category, double price)
        {
            this.ExpenseName = expenseName;
            this.Category = category;
            this.Price = price;
        }
    }
}
