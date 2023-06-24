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
    public class BillManager : IBillService
    {
        private readonly IBillDal _billDal;

        public BillManager(IBillDal billDal)
        {
            _billDal = billDal;
        }

        public void TDelete(Bill t)
        {
            _billDal.Delete(t);
        }

        public Bill TGetByID(int id)
        {
            return _billDal.GetByID(id);    
        }

        public List<Bill> TGetList()
        {
            return _billDal.GetList();
        }

        public void TInsert(Bill t)
        {
            _billDal.Insert(t);
        }

        public void TUpdate(Bill t)
        {
            _billDal.Update(t);
        }
    }
}
