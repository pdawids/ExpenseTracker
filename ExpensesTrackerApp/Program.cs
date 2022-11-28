using System;
using System.Collections.Generic;

namespace ExpensesTrackerApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Welcome to ExpensesTracerApp");

            bool CloseApp = false;

            while (!CloseApp)
            {
                Console.WriteLine();
                Console.WriteLine("You can: 1. Keep expenses in .txt file and see statistics");
                Console.WriteLine("You can: 2. Keep expenses in the memory and see statistics");
                Console.WriteLine("You can: 3. Close App");

                Console.WriteLine("What do you choose: 1,2 or 3?");
                var inputOption = Console.ReadLine();
                                
                switch (inputOption)
                {
                    case "1":
                        AddExpenseInFile();
                        break;
                    case "2":
                        AddExpenseInMemory();
                        break;
                    case "3":
                        CloseApp = true;
                        break;
                }
            }
        }

        private static void InputData(IEmployee employee)
        {
            //SetName(employee, "Daniel");
            //Console.WriteLine($"Employee name changed to:{employee.Name}");

            while (true)
            {
                Console.WriteLine("Enter the expense name:");
                var name = Console.ReadLine();

                Console.WriteLine("Enter the category: ");
                var category = Console.ReadLine();

                Console.WriteLine("Enter the price: ");
                var price = Console.ReadLine();

                if (!IsDigit(name) && !IsDigit(category) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(price))
                {
                    var newExpense = new Expense(name, category, price);
                    employee.AddExpense(newExpense);
                }
                else
                {
                    Console.WriteLine("The expense name and category can't cointain digits, or there is no input data");
                }
                Console.WriteLine("Do you want to continue? Y/N ");
                var input = Console.ReadLine();

                if (input == "N")
                {
                    break;
                }
            }

            var stat = employee.GetStatistics();
            Console.WriteLine($"The lowest expense: {stat.Low}, the highest expense: {stat.High}, the average expense: {stat.Average}");

            employee.PrintOutTheList();
        }

        private static void AddExpenseInMemory()
        {
            Console.WriteLine("Give the employee name");
            var employeeName = Console.ReadLine();

            if (!string.IsNullOrEmpty(employeeName) && IsDigit(employeeName)==false)
            {
                var inMemoryEmployee = new InMemoryEmployeeExpense(employeeName);

                inMemoryEmployee.ExpenseAdded += OnExpenseAdded;
                inMemoryEmployee.ExpenseLimitExceeded += OnExpenseLimitExceeded;

                InputData(inMemoryEmployee);
            }
            else
            {
                Console.WriteLine("Digits are not allowed");
            }
        }

        private static void AddExpenseInFile()
        {
            Console.WriteLine("Give the employee name");
            var employeeName = Console.ReadLine();

            if (!string.IsNullOrEmpty(employeeName) && IsDigit(employeeName) == false)
            {

                var inFileEmployee = new InFileEmployeeExpense(employeeName);

                inFileEmployee.ExpenseAdded += OnExpenseAdded;
                inFileEmployee.ExpenseLimitExceeded += OnExpenseLimitExceeded;

                InputData(inFileEmployee);
            }
            else
            {
                Console.WriteLine("Digits are not allowed");
            }
        }

        static void OnExpenseLimitExceeded(object sender, EventArgs args)
        {
            Console.WriteLine($"You exceeded yor monthly expense limit");
        }

        static void OnExpenseAdded(object sender, EventArgs args)
        {
           Console.WriteLine($"Expense has been added");
        }

        //zadanie 10
        private static void SetName(IEmployee employee,String name)
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

        private static bool IsDigit(String name)
        {
            int count = 0;
            char[] employeeName = name.ToCharArray();

            bool isDigit;
            foreach (var ch in employeeName)
            {
                isDigit = Char.IsDigit(ch);
                if (isDigit == true)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                isDigit = true;
            }
            else
            {
                isDigit = false;
            }
            return isDigit;
        }
    }
}
