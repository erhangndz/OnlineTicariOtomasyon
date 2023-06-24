using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private readonly IExpenseDal _expenseDal;

        public ExpenseManager(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }

        public void TDelete(Expense t)
        {
            _expenseDal.Delete(t);
        }

        public Expense TGetByID(int id)
        {
            return _expenseDal.GetByID(id);
        }

        public List<Expense> TGetList()
        {
           return _expenseDal.GetList();
        }

        public void TInsert(Expense t)
        {
           _expenseDal.Insert(t);
        }

        public void TUpdate(Expense t)
        {
            _expenseDal.Update(t);
        }
    }
}
