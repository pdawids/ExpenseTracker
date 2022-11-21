using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTrackerApp
{
    public class Statistics
    {
        //private double high;
        //private double low;
        //private double average;
        //private double sum;

        public double High { get; set; }
        public double Low { get; set; }
        public double Average { get; set; }
        public double Sum { get; set; }

        public Statistics GetStatistics(List<Expense> expenses)
        {
            var result = new Statistics();

            Low = double.MaxValue;
            High = double.MinValue;
            Average = 0.0;
            Sum = 0.0;

            var count = 0;
            foreach (var expense in expenses)
            {
                Low = Math.Min(Low, expense.Price);
                High = Math.Max(High, expense.Price);
                Average += expense.Price;
                Sum += expense.Price;
                count++;
            }
            Average /= count;
            return result;
        }
        
    }
}
