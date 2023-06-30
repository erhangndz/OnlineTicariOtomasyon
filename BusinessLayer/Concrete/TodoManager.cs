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
    public class TodoManager : ITodoService
    {
        private readonly ITodoDal _todoDal;

        public TodoManager(ITodoDal todoDal)
        {
            _todoDal = todoDal;
        }

        public void TDelete(Todo t)
        {
            _todoDal.Delete(t);
        }

        public Todo TGetByID(int id)
        {
            return _todoDal.GetByID(id);
        }

        public List<Todo> TGetList()
        {
            return _todoDal.GetList();

        }

        public void TInsert(Todo t)
        {
            _todoDal.Insert(t);
        }

        public void TUpdate(Todo t)
        {
            _todoDal.Update(t);
        }
    }
}
