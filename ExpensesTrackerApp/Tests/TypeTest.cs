//using System;
//using Xunit;
//using ExpensesTrackerApp;
//using System.Collections.Generic;
//namespace Tests
//{
//    public class TypeTest
//    {
//        [Fact]
//        public void TestReturnDiffrentObjects()
//        {
//            //arrange
//            //act
//            //assert
//            var exp1 = new Expense("mlotek", "Tools", 50);
//            var exp2 = new Expense("wiadro", "Tools", 33.60);

//            Assert.Equal("mlotek", exp1.ExpenseName);
//            Assert.Equal("wiadro", exp2.ExpenseName);

//            Assert.NotSame(exp1, exp2);

//        }
//        [Fact]
//        public void TestReturnNotSame()
//        {
//            //arrange
//            //act
//            //assert
//            var exp1 = new Expense("mlotek", "Tools", 50);
//            var exp2 = new Expense("wiadro", "Tools", 33.60);

//            Assert.Equal("mlotek", exp1.ExpenseName);
//            Assert.Equal("wiadro", exp2.ExpenseName);

//            Assert.NotSame(exp1, exp2);
//            Assert.False(Object.ReferenceEquals(exp2, exp1));

//            exp1.Equals(exp2);


//        }

//        [Fact]
//        public void TestEquals()
//        {
//            //arrange
//            //act
//            //assert
//            var str1 = "mlotek";
//            var str2 = "wiadro";

//            Assert.False(str1.Equals(str2));

//        }

//        [Fact]
//        public void CanSetNameFromReference()
//        {
//            //arrange
//            //act
//            //assert
//            var exp1 = new Expense("wiadro", "Tools", 123.33);

//            SetName(exp1, "mlotek");

//            Assert.NotEqual("wiadro", exp1.ExpenseName);

//        }
//        private void SetName(Employee expense, string name)
//        {
//            expense.ExpenseName = name;
//        }


//        [Fact]
//        public void CanPassByRef()
//        {
//            //arrange
//            //act
//            //assert
//            var expense = new Expense("mlotek", "tools", 20.22);
//            GetExpenseSetName(out expense, "wiadro", "tools", 20.22);

            
//            Assert.Equal("wiadro", expense.ExpenseName);
//        }
//        private void GetExpenseSetName(out Employee expense,string name, string category, double price)
//        {
//            expense= new Expense(name,category,price);
//        }



//    }
//}
