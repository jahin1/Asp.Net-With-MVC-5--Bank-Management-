using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public class ExpenseRepository: IExpenseRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<Expense> GetAll()
        {
            return context.Expenses.ToList();
        }

      
        public Expense Get(string Expense_date)
        {
            return context.Expenses.SingleOrDefault(d => d.Expense_date == Expense_date);
        }

        public int Insert(Expense expense)
        {
            Expense li = new Expense();
            li.Expense_name = expense.Expense_name;
            li.Expense_date = expense.Expense_date;
            li.Expense_amount = expense.Expense_amount;
            
            //context.Expenses.Add(li);

            context.Expenses.Add(expense);

            return context.SaveChanges();
        }



    }
}
