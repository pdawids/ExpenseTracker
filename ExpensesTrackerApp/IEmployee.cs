namespace ExpensesTrackerApp
{
    public interface IEmployee
    {
        void AddExpense(Expense expense);
        Statistics GetStatistics();
        event ExpenseAddedDelegate ExpenseAdded;
        event ExpensesControlDelegate ExpenseLimitExceeded;
        public string Name { get; set; }
        void PrintOutTheList();
    }
}













