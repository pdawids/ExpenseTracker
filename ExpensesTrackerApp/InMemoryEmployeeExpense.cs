using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTrackerApp
{
    public class InMemoryEmployeeExpense : EmployeeBase
    {
        private List<Expense> expensesList;
        private List<double> expensesSum;

        public List<Expense> ExpenseList
        {
            get
            {
                return expensesList;
            }
            set
            {
                this.expensesList = value;
            }

        }
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

        public InMemoryEmployeeExpense(String name) : base(name)
        {
            expensesList = new List<Expense>();
            expensesSum = new List<double>();
        }
        public override event ExpenseAddedDelegate ExpenseAdded;
        public override event ExpensesControlDelegate ExpenseLimitExceeded;

        public override void AddExpense(Expense exp)
        {
            expensesList.Add(exp);
            expensesSum.Add(exp.Price);

            ExpenseAdded?.Invoke(this, new EventArgs());
            if (ExpenseLimitExceeded != null && expensesSum.Sum() > 100)
            {
                ExpenseLimitExceeded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
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
