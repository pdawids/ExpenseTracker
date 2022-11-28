using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTrackerApp
{
    public delegate void ExpenseAddedDelegate(object sender, EventArgs args);
    public delegate void ExpensesControlDelegate(object sender, EventArgs args);

    //zadanie nr 16
    public abstract class EmployeeBase : Person, IEmployee
    {
        public EmployeeBase(String name) : base(name)
        {
        }

        public abstract event ExpenseAddedDelegate ExpenseAdded;
        public abstract event ExpensesControlDelegate ExpenseLimitExceeded;

        public abstract void AddExpense(Expense exp);

        public abstract Statistics GetStatistics();

        public abstract void PrintOutTheList();
    }
}













