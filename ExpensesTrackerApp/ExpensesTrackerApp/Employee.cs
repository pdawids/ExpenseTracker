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
    //zadanie nr 15
    public class NamedObject
    {
        public NamedObject(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    //zadanie nr 16
    public abstract class EmployeeBase : NamedObject, IEmployee
    {
        public EmployeeBase(String name) : base(name)
        {
        }

        public abstract event ExpenseAddedDelegate ExpenseAdded;
        public abstract event ExpensesControlDelegate ExpensesSumCalc;

        public abstract void AddExpense(Expense exp);

        public abstract Statistics GetStatistics();
        
    }

    public interface IEmployee
    {
        void AddExpense(Expense expense);
        Statistics GetStatistics();
        event ExpenseAddedDelegate ExpenseAdded;
        event ExpensesControlDelegate ExpensesSumCalc;
        public string Name { get; set; }
    }

    //public class Employee : EmployeeBase
    //{
    //    public override event ExpenseAddedDelegate ExpenseAdded;
    //    public override event ExpensesControlDelegate ExpensesSumCalc;

    //    private List<Expense> expensesList = new();
    //    private List<double> expensesSum = new();

    //    public List<Expense> ExpenseList
    //    {
    //        get
    //        {
    //            return expensesList;
    //        }
    //        set
    //        {
    //            this.expensesList = value;
    //        }

    //    }
    //    public List<double> ExpensesSum
    //    {
    //        get
    //        {
    //            return expensesSum;
    //        }
    //        set
    //        {
    //            this.expensesSum = value;
    //        }

    //    }
    //    public Employee(string name) : base(name)
    //    {
    //    }
    //    public override void AddExpense(Expense exp)
    //    {
    //        expensesList.Add(exp);
    //        ExpensesSum.Add(exp.Price);

    //        ExpenseAdded?.Invoke(this, new EventArgs());

    //        //zadanie 14
    //        if (ExpensesSumCalc != null && expensesSum.Sum() > 100)
    //        {
    //            ExpensesSumCalc(this, new EventArgs());
    //        }
    //    }

        

    //    public override Statistics GetStatistics()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class Expense
    {
        private string expenseName;
        private int price;
        private string category;

        public int Price
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
            if (Int32.TryParse(str, out int num))
            {
                this.Price = num;
                // .. rest of your code
            }
        }
    }

    public class InMemoryEmployeeExpense : EmployeeBase
    {
        private List<Expense> expensesList = new();
        private List<double> expensesSum = new();

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
        }
        public override event ExpenseAddedDelegate ExpenseAdded;
        public override event ExpensesControlDelegate ExpensesSumCalc;

        public override void AddExpense(Expense exp)
        {
            expensesList.Add(exp);
            ExpensesSum.Add(exp.Price);

            ExpenseAdded?.Invoke(this, new EventArgs());
            if (ExpensesSumCalc != null && expensesSum.Sum() > 100)
            {
                ExpensesSumCalc(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public void PrintOutTheList()
        {
            Console.WriteLine("Expense list:");
            foreach (var expense in expensesList)
            {
                Console.WriteLine(expense.ExpenseName + ", " + expense.Category + ", " + expense.Price);
            }
        }
        //public void RemoveIndex(List<Expense> expensesList)
        //{
        //    expensesList.RemoveAt(1);
        //}
    }

    public class InFileEmployeeExpense : EmployeeBase
    {
        public InFileEmployeeExpense(String name) : base(name)
        {
        }

        public override event ExpenseAddedDelegate ExpenseAdded;
        public override event ExpensesControlDelegate ExpensesSumCalc;

        public override void AddExpense(Expense exp)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine($"{ exp.ExpenseName},{exp.Category},{exp.Price}");
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
        
    }
}













