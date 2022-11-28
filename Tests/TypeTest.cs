using System;
using Xunit;
using ExpensesTrackerApp;
using System.Collections.Generic;
namespace Tests
{
    public class TypeTest
    {
        [Fact]
        public void TestReturnDiffrentObjects()
        {
            //arrange
            //act
            //assert
            var exp1 = new Expense("mlotek", "Tools", 50);
            var exp2 = new Expense("wiadro", "Tools", 33.60);

            Assert.Equal("mlotek", exp1.ExpenseName);
            Assert.Equal("wiadro", exp2.ExpenseName);

            Assert.NotSame(exp1, exp2);
        }
        [Fact]
        public void TestReturnNotSame()
        {
            //arrange
            //act
            //assert
            var exp1 = new Expense("mlotek", "Tools", 50);
            var exp2 = new Expense("wiadro", "Tools", 33.60);

            Assert.Equal("mlotek", exp1.ExpenseName);
            Assert.Equal("wiadro", exp2.ExpenseName);

            Assert.NotSame(exp1, exp2);
            Assert.False(Object.ReferenceEquals(exp2, exp1));

            exp1.Equals(exp2);
        }

        [Fact]
        public void TestEquals()
        {
            //arrange
            //act
            //assert
            var str1 = "mlotek";
            var str2 = "wiadro";

            Assert.False(str1.Equals(str2));
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            //act
            //assert
            var empl = new InMemoryEmployeeExpense("Dawid");
            SetName(empl, "Witek");
            Assert.Equal("Witek", empl.Name);
        }
        private void SetName(InMemoryEmployeeExpense employee, string name)
        {
            employee.Name = name;
        }

        [Fact]
        public void CanPassByRef()
        {
            //arrange
            //act
            //assert
            var emp1 = GetEmployee("Dawid");
            InMemoryEmployeeSetName(out emp1, "New Name");
            Assert.Equal("New Name", emp1.Name);
        }
        private void InMemoryEmployeeSetName(out InMemoryEmployeeExpense empl, string name)
        {
            empl = new InMemoryEmployeeExpense(name);
        }

        private InMemoryEmployeeExpense GetEmployee(string employee)
        {
            return new InMemoryEmployeeExpense(employee);
        }
    }
}
