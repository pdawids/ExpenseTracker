using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTrackerApp
{
    public class InFileEmployeeExpense : EmployeeBase
    {
        private const string fileName = ".audit.txt";

        private readonly List<Expense> expensesList;
        private List<double> expensesSum;

        public List<double> ExpensesSum
        {
            get
            {
                return expensesSum;
            }
            set
            {
                this.expensesSum = value;
            }
        }

        public InFileEmployeeExpense(String name) : base(name)
        {
            expensesList = new List<Expense>();
            expensesSum = new List<double>();
        }

        public override event ExpenseAddedDelegate ExpenseAdded;
        public override event ExpensesControlDelegate ExpenseLimitExceeded;

        public override void AddExpense(Expense exp)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            expensesSum.Add(exp.Price);
            
            using var writer = File.AppendText($"{Name}.txt");
            using var writerAudit = File.AppendText($"{Name}{fileName}");

            writer.WriteLine($"{ exp.ExpenseName},{exp.Category},{exp.Price}");
            writerAudit.WriteLine($"{exp.ExpenseName},{exp.Category},{exp.Price},{date}");

            ExpenseAdded?.Invoke(this, new EventArgs());
            if (ExpenseLimitExceeded != null && expensesSum.Sum() > 100)
            {
                ExpenseLimitExceeded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    string[] col = line.Split(',');

                    var name = col[0];
                    var category = col[1];
                    var price = col[2];

                    var expense = new Expense(name, category, price);
                    expensesList.Add(expense);
                    line = reader.ReadLine();
                }
            }
            statistics.GetStatistics(expensesList);
            return statistics;
        }
        
        public override void PrintOutTheList()
        {
            Console.WriteLine("Expense list:");
            foreach (var expense in expensesList)
            {
                Console.WriteLine(expense.ExpenseName + ", " + expense.Category + ", " + expense.Price);
            }
        }
    }
}
