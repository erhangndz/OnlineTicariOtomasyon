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
    public class CurrentManager : ICurrentService
    {
        private readonly ICurrentDal _currentDal;

        public CurrentManager(ICurrentDal currentDal)
        {
            _currentDal = currentDal;
        }

        public void TDelete(Current t)
        {
            _currentDal.Delete(t);
        }

        public Current TGetByID(int id)
        {
           return _currentDal.GetByID(id);
        }

        public List<Current> TGetList()
        {
            return _currentDal.GetList();
        }

        public void TInsert(Current t)
        {
            _currentDal.Insert(t);
        }

        public void TUpdate(Current t)
        {
            _currentDal.Update(t);
        }
    }
}
