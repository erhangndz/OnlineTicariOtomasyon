using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public List<Transaction> Transactions { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public bool Status { get; set; }
    }
}
