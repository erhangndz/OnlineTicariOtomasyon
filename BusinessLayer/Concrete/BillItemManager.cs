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
    public class BillItemManager : IBillItemService
    {
        private readonly IBillItemDal _billItemDal;

        public BillItemManager(IBillItemDal billItemDal)
        {
            _billItemDal = billItemDal;
        }

        public void TDelete(BillItem t)
        {
           _billItemDal.Delete(t);
        }

        public BillItem TGetByID(int id)
        {
            return _billItemDal.GetByID(id);
        }

        public List<BillItem> TGetList()
        {
            return _billItemDal.GetList();
        }

        public void TInsert(BillItem t)
        {
            _billItemDal.Insert(t);
        }

        public void TUpdate(BillItem t)
        {
            _billItemDal.Update(t);
        }
    }
}
