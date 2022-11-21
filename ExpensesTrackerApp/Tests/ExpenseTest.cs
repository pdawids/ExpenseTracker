using System;
using Xunit;
using ExpensesTrackerApp;
using System.Collections.Generic;
namespace Tests
{
    public class ExpenseTest
    {

        public delegate string WriteMessge(string message);

       int counter= 0;

        [Fact]

        public void WriteMessageDelgateCanPointToMethod()
        {
            WriteMessge del;
            del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;

            var result = del("dziala");

            Assert.Equal("dziala", result);
            Assert.Equal(3, counter);
        }

        public string ReturnMessage(string message)
        {
            counter++;
            return message;
        }

        public string ReturnMessage2(string message)
        {
            counter++;
            return message;
        }

        //    [Fact]
        //    public void TestCheckAverageHighLow()
        //    {
        //        //arrange
        //        //act
        //        //assert
        //        List<Employee> expenses = new();

        //        var empl = new Expense("mlotek", "Tools", "50");
        //        var empl1 = new Expense("wiadro", "Tools", "33.60");
        //        var empl2 = new Expense("farba", "Tools", "33.60);

        //        expenses.Add(empl);
        //        expenses.Add(empl1);
        //        expenses.Add(empl2);

        //        var result = new Statistics();

        //        result.GetStatistics(expenses);

        //        Assert.Equal(50, result.High);
        //        Assert.Equal(33.60, result.Low);
        //        Assert.Equal(39.0667, result.Average,4);

        //    }
    }
}
