using System;
using System.Collections.Generic;

namespace ExpensesTrackerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new InMemoryEmployeeExpense("Dawid");

            var exp1 = new Expense("Paliwo", "Transport", "1");
            var exp2 = new Expense("Parking", "Transport", "2");
            var exp3 = new Expense("Parking", "Transport", "3");
            var exp4 = new Expense("Parking", "Transport", "4");
            employee.AddExpense(exp1);
            employee.AddExpense(exp2);
            employee.AddExpense(exp3);
            employee.AddExpense(exp4);

            InputData(employee);

            employee.ExpenseAdded += OnExpenseAdded;
            employee.ExpensesSumCalc += OnExpenseLimitExceeded;

            SetName(employee, "Daniel");
            Console.WriteLine(employee.Name);

            employee.PrintOutTheList();

            var stat = new Statistics();
            stat.GetStatistics(employee.ExpenseList);
            Console.WriteLine($"The lowest expense: {stat.Low}, the highest expense: {stat.High}, the average expense: {stat.Average}");

            var savedInFile = new InFileEmployeeExpense(employee.Name);
            var expenseList = employee.ExpenseList;
            
            foreach (var item in expenseList)
            {
                try
                {
                    employee.AddExpense(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The error encountered", ex.Message);
                    
                }
                
            }
        }

        private static void InputData(InMemoryEmployeeExpense employee)
        {
            while (true)
            {
                Console.WriteLine("Enter the expense name:");
                var name = Console.ReadLine();

                Console.WriteLine("Enter the category: ");
                var category = Console.ReadLine();

                Console.WriteLine("Enter the price: ");
                var price = Console.ReadLine();

                var newExpense = new Expense(name, category, price);
                employee.AddExpense(newExpense);

                Console.WriteLine("Do you want to continue? Y/N ");
                var input = Console.ReadLine();

                if (input == "N")
                {
                    break;
                }
            }
        }

        private static void OnExpenseLimitExceeded(object sender, EventArgs args)
        {
            Console.WriteLine($"You exceeded yor monthly expense limit");
        }

        static void OnExpenseAdded(object sender, EventArgs args)
        {
           Console.WriteLine($"Expense has been added");
           
        }

        //zadanie 10
        private static void SetName(InMemoryEmployeeExpense employee,String name)
        {
            bool isDigit=false; 

            char[] employeeName = name.ToCharArray();

            foreach (var ch in employeeName)
            {
                isDigit = Char.IsDigit(ch);
            }
                       
            if (!isDigit)
            {
                employee.Name = name;
            }
            else
            {
                Console.WriteLine("You can't use digit in the Name");
            }
        }
    }
}
