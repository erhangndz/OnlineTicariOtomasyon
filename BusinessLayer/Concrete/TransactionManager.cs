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
    public class TransactionManager : ITransactionService
    {
        private readonly ITransactionDal _transactionDal;

        public TransactionManager(ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        public void TDelete(Transaction t)
        {
           _transactionDal.Delete(t);
        }

        public List<Transaction> TGetAll()
        {
           return  _transactionDal.GetAll();
        }

        public Transaction TGetByID(int id)
        {
           return _transactionDal.GetByID(id);  
        }

        public List<Transaction> TGetList()
        {
            return _transactionDal.GetList();
        }

        public void TInsert(Transaction t)
        {
           _transactionDal.Insert(t);
        }

        public void TUpdate(Transaction t)
        {
            _transactionDal.Update(t);
        }
    }
}
